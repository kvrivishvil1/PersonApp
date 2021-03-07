using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PersonsApp.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PersonsApp.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private async Task ConvertException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            _logger.LogError(ex.Message);

            var result = HandleException(ex);

            context.Response.StatusCode = (int)result.Item1;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(result.Item2));
        }

        private (HttpStatusCode, Error) HandleException(Exception ex) => ex switch
        {
            ValidationException validationException => (HttpStatusCode.BadRequest, new Error { ValidationErrors = validationException.ValidationErrors }),
            BadRequestException _ => (HttpStatusCode.BadRequest, new Error { ErrorMessage = ex.Message }),
            NotFoundException _ => (HttpStatusCode.NotFound, new Error { ErrorMessage = ex.Message }),
            DublicateException _ => (HttpStatusCode.Conflict, new Error { ErrorMessage = ex.Message }),
            Exception _ => (HttpStatusCode.BadRequest, new Error { ErrorMessage = ex.Message }),
            _ => (HttpStatusCode.BadRequest, new Error { ErrorMessage = "Unknown Error" }),
        };
    }
    public class Error
    {
        public string ErrorMessage { get; set; }
        public IEnumerable<string> ValidationErrors { get; set; }
    }
}
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonsApp.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IEnumerable<string> ValidationErrors { get; set; }
        public ValidationException(IEnumerable<string> failures)
        {
            ValidationErrors = failures.ToList();
        }
    }
}

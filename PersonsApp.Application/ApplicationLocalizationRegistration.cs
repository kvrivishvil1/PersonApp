using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PersonsApp.Application
{
    public static class ApplicationLocalizationRegistration
    {
        public static IApplicationBuilder RegisterLocalization(this IApplicationBuilder app)
        {

            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture("ka"),
                SupportedCultures = new[] { new CultureInfo("ka"), new CultureInfo("en") },
                SupportedUICultures = new[] { new CultureInfo("ka"), new CultureInfo("en") }
            });

            return app;
        }
    }
}

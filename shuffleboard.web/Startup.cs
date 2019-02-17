using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace shuffleboard.web
{
    public class Startup
    {
        private IConfiguration _confi;

        public Startup(IConfiguration confi)
        {
            _confi = confi;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.Conventions.Add(new DashedRoutingConvention()));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        private void ConfigureRoute(IRouteBuilder routeBuilder)
        {
         //   //Home/Index 
         //   routeBuilder.MapRoute(
         //    "CategoryRoute", // Route name
         //    "store/{languagecode}/{id}", // URL with parameters
         //    new { controller = "Store", action = "category", languagecode = "en-US"} // Parameter defaults
         //);
            routeBuilder.MapRoute("Default", "{controller = Home}/{action = Index}/{id?}");

        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //    DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //  defaultFilesOptions.DefaultFileNames.Clear();
            //    defaultFilesOptions.DefaultFileNames.Add("foo.html");
            // app.UseDefaultFiles(defaultFilesOptions);
            app.UseStaticFiles();
            app.UseMvc(ConfigureRoute);

            app.Run(async (context) =>
            {

                await context.Response.WriteAsync(
                   "Hosting Environment " + env.EnvironmentName
                        );

            });
        }
    }
}

//public class SlugifyParameterTransformer : IOutboundParameterTransformer
//{
//    public string TransformOutbound(object value)
//    {
//        // Slugify value
//        return value == null ? null : Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
//    }
//}

public class DashedRoutingConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        var hasRouteAttributes = controller.Selectors.Any(selector =>
                                           selector.AttributeRouteModel != null);
        if (hasRouteAttributes)
        {
            // This controller manually defined some routes, so treat this 
            // as an override and not apply the convention here.
            return;
        }

        foreach (var controllerAction in controller.Actions)
        {
            foreach (var selector in controllerAction.Selectors.Where(x => x.AttributeRouteModel == null))
            {
                var template = new StringBuilder();

                if (controllerAction.Controller.ControllerName != "Home")
                {
                    template.Append(PascalToKebabCase(controller.ControllerName));
                }

                if (controllerAction.ActionName != "Index")
                {
                    template.Append("/" + PascalToKebabCase(controllerAction.ActionName));
                }

                selector.AttributeRouteModel = new AttributeRouteModel()
                {
                    Template = template.ToString()
                };
            }
        }
    }

    public static string PascalToKebabCase(string value)
    {
        if (string.IsNullOrEmpty(value))
            return value;

        return Regex.Replace(
            value,
            "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])",
            "-$1",
            RegexOptions.Compiled)
            .Trim()
            .ToLower();
    }
}

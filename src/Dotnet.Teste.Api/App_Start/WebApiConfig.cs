using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Dotnet.Teste.Api.App_Start;
using Dotnet.Teste.Api.Log;

namespace Dotnet.Teste.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            config.MessageHandlers.Add(new MonitorLog());

            SwaggerConfig.Register();
        }
    }
}

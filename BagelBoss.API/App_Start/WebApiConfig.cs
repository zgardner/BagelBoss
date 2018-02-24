using System;
using System.Web;
using System.Web.Http;

namespace BagelBoss.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{locationName}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { locationName = @"[A-Za-z]+"}
            );
        }

        public static String GetCurrentRequestLocationName()
        {
            var currentRequest = HttpContext.Current.Request;
            var path = currentRequest.Path.Split('/');

            return path[2];
        }
    }
}

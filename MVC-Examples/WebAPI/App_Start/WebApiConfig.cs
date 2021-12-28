using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPI.CustomActionFilters;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new ExceptionFilter());
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{name}",
                defaults: new { name = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
               name: "UserRoute",
               routeTemplate: "api/{controller}/{username}/{emailid}/{password}",
               defaults: new { emailid = RouteParameter.Optional, password = RouteParameter.Optional }
               );
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SoftimRestTask
{
    /// <summary>
    /// Setting of Web API
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Web API configuration and services
        /// Web API routes
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}"
            );
        }
    }
}

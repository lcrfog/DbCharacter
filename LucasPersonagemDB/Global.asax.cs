﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;


namespace LucasPersonagemDB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Ajustando serializacao para webAPI

            GlobalConfiguration
                    .Configuration
                    .Formatters
                    .JsonFormatter
                    .SerializerSettings
                    .ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration
                .Configuration
                .Formatters
                .Remove(
                    GlobalConfiguration
                        .Configuration
                        .Formatters
                        .XmlFormatter
                );
        }
    }
}
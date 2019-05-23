using Autofac.Integration.Mvc;
using AutoMapper;
using Restaurant.WebApplication.App_Start;
using Restaurant.WebApplication.Helpers.AutoMapperProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Restaurant.WebApplication
{
    public class MvcApplication :  System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
        }
    }
}

using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Restaurant.Database;
using Restaurant.Database.Repositories.Abstract;
using Restaurant.Database.Repositories.Concrete;
using Restaurant.Domain.Services.Abstract;
using Restaurant.Domain.Services.Concrete;
using Restaurant.WebApplication.Helpers.AutoMapperProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Restaurant.WebApplication.App_Start
{
    public static class IoCConfig
    {
        internal static IContainer Container => _container;

        private static IContainer _container;

        /// <summary>
        /// Registers services and creates container 
        /// </summary>
        public static IContainer RegisterServices()
        {
            var builder = new ContainerBuilder();

            // Register all controllers in this assembly
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            RegisterServices(builder);
            RegisterRepositories(builder);
            //register autoMapper
            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            }));
            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper())
                .As<IMapper>().InstancePerLifetimeScope();
            _container = builder.Build();
            return Container;
        }
        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<TestService>()
                .As<ITestService>().SingleInstance();
        }
        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<TestRepository>()
                .As<ITestRepository>().SingleInstance();
        }
    }
}
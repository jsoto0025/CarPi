using Autofac;
using CarPooling.Configuration.AppConfig;
using CarPooling.Session;
using CommonServiceLocator;
using Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace CarPooling
{
    static class Bootstrap
    {
        public static void Initialize()
        {

            var builder = new ContainerBuilder();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder.RegisterAssemblyTypes(assemblies)
                      .Where(t => t.Name.EndsWith("Repository"))
                      .AsImplementedInterfaces();

            builder.RegisterType<Login>();
            builder.RegisterType<RoutesSelection>();

            builder.RegisterType<SessionData>()
                .As<ISessionData>()
                .SingleInstance();

            // Configuration object registration
            builder.RegisterInstance<IConfiguration>(LoadConfiguration());

            App.DependencyContainer = builder.Build();
        }

        private static IConfiguration LoadConfiguration()
        {
            return DependencyService.Get<IAppConfigReader>()
                .LoadConfig("config.json");
        }
    }
}

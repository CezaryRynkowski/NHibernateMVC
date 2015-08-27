using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using NHibernateMVC.App_Start;
using NHibernateMVC.Infrastructure.IoC;

namespace NHibernateMVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        private static readonly IWindsorContainer container = new WindsorContainer();

        public static IWindsorContainer Container
        {
            get
            {
                return container;
            }
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }


        protected void Application_Start()
        {
            InitWindsor();
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));

            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void InitWindsor()
        {
            Container.Register(
                Component.For<IWindsorContainer>().Instance(Container).LifestyleSingleton()
                );
            Container.Install(FromAssembly.This());
        }
    }
}
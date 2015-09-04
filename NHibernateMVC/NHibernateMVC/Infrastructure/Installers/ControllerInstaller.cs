using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NHibernateMVC.Controllers;

namespace NHibernateMVC.Infrastructure.Installers
{
    /// <summary>
    /// Registers controller in Windsor
    /// </summary>
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
           container.Register(
          Classes.FromThisAssembly()
          .BasedOn(typeof(System.Web.Mvc.ControllerBase))
          .LifestyleTransient());
        }
    }

}
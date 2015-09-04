using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using NHibernateMVC.Infrastructure.Command;

namespace NHibernateMVC.Infrastructure.IoC
{
    /// <summary>
    /// Installer for infrastructure components
    /// command runner
    /// </summary>
    public class InfrastructureInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container,
            Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Component.For<CommandRunner>().ImplementedBy<CommandRunner>().LifestyleTransient());
        }
    }
}
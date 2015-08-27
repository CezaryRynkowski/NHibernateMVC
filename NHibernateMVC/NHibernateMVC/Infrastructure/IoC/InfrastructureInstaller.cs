using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using NHibernateMVC.Infrastructure.Command;

namespace NHibernateMVC.Infrastructure.IoC
{
    public class InfrastructureInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container,
            Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Component.For<CommandRunner>().ImplementedBy<CommandRunner>().LifestyleTransient());
        }
    }
}
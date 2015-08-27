using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NHibernateMVC.Data;

namespace NHibernateMVC.Infrastructure.Installers
{
    public class DaoInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof (IDao<>))
                .Forward(typeof (IDao<>))
                .ImplementedBy(typeof (Dao<>)));
        }
    }
}
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NHibernateMVC.Infrastructure.SessionManagement;
using NHibernate;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg;
using NHibernate.Cfg.Loquacious;
using NHibernate.Dialect;

namespace NHibernateMVC.Infrastructure.Installers
{
    /// <summary>
    /// Installer for NHibernate, registers session factory and session in container
    /// </summary>
    public class NHibernateInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ISessionFactory>().UsingFactoryMethod(
                    kernel => BuildSessionFactory()).LifestyleSingleton(),
                Component.For<ISession>().UsingFactoryMethod(kernel =>
                {
                    var session = kernel.Resolve<ISessionFactory>().OpenSession();
                    session.FlushMode = FlushMode.Commit;
                    return session;
                }).LifestylePerWebRequest()
                );

            container.AddFacility<TypedFactoryFacility>();

            container.Register(Component.For<NHibernateSessionModule>());

            container.Register(Component.For<ISessionFactoryProvider>().AsFactory());

            container.Register(Component.For<IEnumerable<ISessionFactory>>()
                                        .UsingFactoryMethod(k => k.ResolveAll<ISessionFactory>()));

            HttpContext.Current.Application[SessionFactoryProvider.Key]
                            = container.Resolve<ISessionFactoryProvider>();
        }

        private ISessionFactory BuildSessionFactory()
        {
            var configuration = new Configuration();
            configuration.DataBaseIntegration(db =>
            {
                db.Dialect<MsSql2008Dialect>();
                db.ConnectionStringName = "NHibernate_CRUD";
            });
            configuration.Properties[Environment.CurrentSessionContextClass]
                            = typeof(LazySessionContext).AssemblyQualifiedName;

            configuration.Cache(c => c.UseQueryCache = false);

            configuration.Proxy(p => p.ProxyFactoryFactory<ProxyFactoryFactory>());

            configuration.AddAssembly(GetType().Assembly);

            return configuration.BuildSessionFactory();
        }
    }
}
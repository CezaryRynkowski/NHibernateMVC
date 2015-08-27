//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using Castle.Facilities.Logging;
//using Castle.MicroKernel.Registration;
//using Castle.MicroKernel.SubSystems.Configuration;
//using Castle.Windsor;

//namespace NHibernateMVC.Infrastructure.Installers
//{
//    /// <summary>
//    /// Installs loggging facility configured to use log4net, which in turns is configured using its own configuration file logging.config
//    /// </summary>
//    public class LoggingInstaller : IWindsorInstaller
//    {
//        /// <summary>
//        /// Installs loggging facility configured to use log4net, which in turns is configured using its own configuration file logging.config
//        /// </summary>
//        public void Install(IWindsorContainer container, IConfigurationStore store)
//        {
//            container.AddFacility<LoggingFacility>(
//                facility => facility.UseLog4Net("logging.config")
//                );
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace NHibernateMVC.Infrastructure.IoC
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private IWindsorContainer _container;

        /// <summary>
        /// Creates factory
        /// </summary>
        /// <param name="container">windsor</param>
        public WindsorControllerFactory(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext context, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404,
                    string.Format(
                        "The controller for path '{0}' could not be found or it does not implement IController.",
                        context.HttpContext.Request.Path));
            }

            var ctr = (IController) _container.Resolve(controllerType);
            if (ctr is Infrastructure.Web.ControllerBase)
            {
                ((Infrastructure.Web.ControllerBase)ctr).Container = _container;
            }

            return ctr;
        }

        public override void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;

            if (disposable != null)
            {
                disposable.Dispose();
            }

            _container.Release(controller);
        }
    }
}
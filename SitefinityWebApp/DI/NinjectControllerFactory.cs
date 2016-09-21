using Ninject;
using SitefinityWebApp.Tests.Mocks;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using Telerik.Sitefinity.Frontend;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers;
using Telerik.Sitefinity.Modules.News;

namespace SitefinityWebApp.DI
{
    public class NinjectControllerFactory : FrontendControllerFactory
    {
        public NinjectControllerFactory()
        {
            this.ninjectKernel = FrontendModule.Current.DependencyResolver;

            // Add dependency bindings here

            this.ninjectKernel.Bind<INewsManagerWrapper>().To<NewsManagerWrapper>();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }

            var resolvedController = this.ninjectKernel.Get(controllerType);
            IController controller = resolvedController as IController;

            return controller;
        }

        private IKernel ninjectKernel;
    }
}
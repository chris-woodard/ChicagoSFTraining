using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Frontend;
using Telerik.Sitefinity.Frontend.Navigation.Mvc.Models;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Services;
using Telerik.Microsoft.Practices.Unity;
using SitefinityWebApp.DI;
using Telerik.Sitefinity.Mvc;
using System.Web.Mvc;

namespace SitefinityWebApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Bootstrapper.Initialized += this.Bootstrapper_Initialized;
            SystemManager.ApplicationStart += SystemManager_ApplicationStart;
            Bootstrapper.Bootstrapped += Bootstrapper_Bootstrapped;
        }

        private void Bootstrapper_Bootstrapped(object sender, EventArgs e)
        {
            // Use Service Locator mechanism to register our NinjectController factory which will provide DI for controller dependencies.
            ObjectFactory.Container.RegisterType<ISitefinityControllerFactory, NinjectControllerFactory>(new ContainerControlledLifetimeManager());

            var factory = ObjectFactory.Resolve<ISitefinityControllerFactory>();

            // Set our factory as a default controller factory
            ControllerBuilder.Current.SetControllerFactory(factory);
        }

        private void SystemManager_ApplicationStart(object sender, EventArgs e)
        {
            Res.RegisterResource<AdderResources>();
        }

        private void Bootstrapper_Initialized(object sender, ExecutedEventArgs e)
        {
            if (e.CommandName == "Bootstrapped")
            {
                FrontendModule.Current.DependencyResolver.Rebind<INavigationModel>().To<CustomNavigationModel>();
            }
        }
    }
}
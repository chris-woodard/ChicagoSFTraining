using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [Localization(typeof(AdderResources))]
    [ControllerToolboxItem(Title = "Adder", Name = "Adder", SectionName = "Custom")]
    public class AdderController : Controller
    {
        // GET: Adder
        public ActionResult Index()
        {
            int sum = 2 + 3;

            return View("Index", sum);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.Index().ExecuteResult(this.ControllerContext);
        }
    }
}
using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Title = "Adder", Name = "Adder", SectionName = "Custom")]
    public class AdderController : Controller
    {
        public int A { get; set; }
        public int B { get; set; }
        
        public ActionResult Index()
        {
            var model = new AdderModel(A, B);
            return View("Index", model);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.Index().ExecuteResult(this.ControllerContext);
        }
    }
}
using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Title = "Hello World", Name = "HelloWorld", SectionName = "Custom")]
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            var model = new HelloWorldModel();
            model.Message = "Hello World!";
            return View(model);
        }

        public ActionResult RandomNumber()
        {
            var model = new HelloWorldModel();
            model.GeneratedNumber = new Random().Next(1, 50);
            return View("RandomNumber", model);
        }
    }
}
using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Title = "Breaking News", Name = "BreakingNews", SectionName = "Custom")]
    public class BreakingNewsController : Controller
    {
        public string Message { get; set; }

        // GET: BreakingNews
        public ActionResult Index()
        {
            var model = new BreakingNewsModel();
            model.Message = Message;
            return View("Index", model);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.Index().ExecuteResult(this.ControllerContext);
        }
    }
}
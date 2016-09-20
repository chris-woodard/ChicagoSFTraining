using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Title = "Webinar", Name = "Webinar", SectionName = "Custom")]
    public class WebinarController : Controller
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string SelectedItem { get; set; }

        // GET: Webinar
        public ActionResult Index()
        {
            var model = new WebinarModel() { Title = this.Title, Description = this.Description, StartTime = this.StartTime, EndTime = this.EndTime };
            return View("Index", model);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.Index().ExecuteResult(this.ControllerContext);
        }
    }
}
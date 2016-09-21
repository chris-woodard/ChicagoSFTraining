using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Modules.News;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Taxonomies;
using Telerik.Sitefinity.Taxonomies.Model;
using Telerik.Sitefinity.Model;
using Telerik.OpenAccess;
using Telerik.Sitefinity.Abstractions;
using SitefinityWebApp.Tests.Mocks;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Title = "Breaking News", Name = "BreakingNews", SectionName = "Custom")]
    public class BreakingNewsController : Controller
    {
        private NewsManager newsManager;
        public BreakingNewsController(INewsManagerWrapper newsManagerWrapper)
        {
            this.newsManager = newsManagerWrapper.GetManager();
        }

        public string Date { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string SelectedItem { get; set; }

        // GET: BreakingNews
        public ActionResult Index()
        {
            var firstNewsItem = newsManager.GetNewsItems().FirstOrDefault();

            BreakingNewsModel model = new BreakingNewsModel();
            model.Message = firstNewsItem.Title;

            return View("Index", model);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.Index().ExecuteResult(this.ControllerContext);
        }
    }
}
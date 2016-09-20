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

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Title = "Breaking News", Name = "BreakingNews", SectionName = "Custom")]
    public class BreakingNewsController : Controller
    {
        public string Date { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string SelectedItem { get; set; }

        // GET: BreakingNews
        public ActionResult Index()
        {
            TaxonomyManager tManager = TaxonomyManager.GetManager();
            var tag = tManager.GetTaxa<FlatTaxon>().Where(t => t.Id == new Guid("5de91ba4-2220-62db-a387-ff00001daa0d")).FirstOrDefault();
            var model = new BreakingNewsModel();
            if (tag != null)
            {
                NewsManager nManager = NewsManager.GetManager();
                var newsItem = nManager.GetNewsItems().Where(n => n.GetValue<TrackedList<Guid>>("Tags").Contains(tag.Id) && n.Status == Telerik.Sitefinity.GenericContent.Model.ContentLifecycleStatus.Live).FirstOrDefault();
                model.Message = newsItem.PublicationDate.ToString() + ' ' + newsItem.Title;
            }
            return View("Index", model);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.Index().ExecuteResult(this.ControllerContext);
        }
    }
}
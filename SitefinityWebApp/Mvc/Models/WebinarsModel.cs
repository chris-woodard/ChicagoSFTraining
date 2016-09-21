using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.Modules.Events;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Data.ContentLinks;
using Telerik.Sitefinity.News.Model;
using Telerik.Sitefinity.Modules.News;
using Telerik.Sitefinity.Modules.Blogs;
using Telerik.Sitefinity.Events.Model;
using Telerik.Sitefinity.DynamicModules.Model;
using SitefinityWebApp.Mvc.ViewModels;

namespace SitefinityWebApp.Mvc.Models
{
    public class WebinarsModel
    {
        public IEnumerable<WebinarViewModel> GetContentList()
        {
            var result = new List<WebinarViewModel>();

            Type webinarType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.Webinars.Webinar");

            using (var eManager = EventsManager.GetManager())
            {
                using (var manager = DynamicModuleManager.GetManager())
                {
                    var webinars = manager.GetDataItems(webinarType).Where(d => d.Status == Telerik.Sitefinity.GenericContent.Model.ContentLifecycleStatus.Live);
                    var events = eManager.GetEvents().Where(e => e.Status == Telerik.Sitefinity.GenericContent.Model.ContentLifecycleStatus.Live);

                    var joined = (from w in webinars join e in events on w.GetValue<string>("Title") equals e.Title.ToString() select new WebinarViewModel() { Title = w.GetValue<string>("Title"), EventContent = e.Content.ToString() });

                    result = joined.ToList();
                }
            }

            return result;
        }
    }
}
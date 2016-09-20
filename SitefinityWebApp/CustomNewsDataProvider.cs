using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Lifecycle;
using Telerik.Sitefinity.Modules.News;
using Telerik.Sitefinity.News.Model;
using Telerik.Sitefinity.Security.Model;

namespace SitefinityWebApp
{
    public class CustomNewsDataProvider : NewsDataProvider, ICommonDataProvider
    {
        public override LanguageData CreateLanguageData()
        {
            throw new NotImplementedException();
        }

        public override LanguageData CreateLanguageData(Guid id)
        {
            throw new NotImplementedException();
        }

        public override NewsItem CreateNewsItem()
        {
            throw new NotImplementedException();
        }

        public override NewsItem CreateNewsItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public override void Delete(NewsItem newsItemToDelete)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<LanguageData> GetLanguageData()
        {
            throw new NotImplementedException();
        }

        public override LanguageData GetLanguageData(Guid id)
        {
            throw new NotImplementedException();
        }

        public override NewsItem GetNewsItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<NewsItem> GetNewsItems()
        {
            var newsItems = new List<NewsItem>()
            {
                App.WorkWith().NewsItem().CreateNew(Guid.NewGuid()).Get(),
                App.WorkWith().NewsItem().CreateNew(Guid.NewGuid()).Get()
            };

            var count = 1;
            foreach(var newsItem in newsItems)
            {
                newsItem.Title = "Sample news item " + count;
                count++;
            }

            return newsItems.AsQueryable();
        }

        public override ISecuredObject GetSecurityRoot(bool create)
        {
            var key = String.Concat(this.RootKey, this.Name);
            return new SecurityRoot(this.Name, this.GetNewGuid(), this.SupportedPermissionSets, this.PermissionsetObjectTitleResKeys) { Key = key };
        }
    }
}
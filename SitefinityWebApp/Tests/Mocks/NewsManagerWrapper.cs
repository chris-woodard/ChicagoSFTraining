using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Modules.News;

namespace SitefinityWebApp.Tests.Mocks
{
    public class NewsManagerWrapper : INewsManagerWrapper
    {
        public NewsManager GetManager()
        {
            return NewsManager.GetManager();
        }
    }
}
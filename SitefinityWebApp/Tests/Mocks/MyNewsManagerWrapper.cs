using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Modules.News;

namespace SitefinityWebApp.Tests.Mocks
{
    public class MyNewsManagerWrapper : INewsManagerWrapper
    {
        public NewsManager GetManager()
        {
            return new MyNewsManager();
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SitefinityWebApp.Mvc.Controllers;
using SitefinityWebApp.Mvc.Models;
using SitefinityWebApp.Tests.Mocks;
using System.Linq;
using System.Web.Mvc;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Modules.News;

namespace SitefinityWebApp.Tests
{
    [TestClass]
    public class BreakingNewsControllerTest
    {
        [TestMethod]
        public void IndexAction_CorrectlySetsTitle_ToModel()
        {
            // Pass my mocked instance of a news manager to the controller.
            var myNewsManagerWrapper = new MyNewsManagerWrapper();
            BreakingNewsController controller = new BreakingNewsController(myNewsManagerWrapper);

            ViewResult result = controller.Index() as ViewResult;
            BreakingNewsModel breakingNewsModel = result.Model as BreakingNewsModel;

            string expectedFirstItemTitle = myNewsManagerWrapper.GetManager().GetNewsItems().First().Title;

            Assert.AreEqual<string>(expectedFirstItemTitle, breakingNewsModel.Message);
        }
    }
}
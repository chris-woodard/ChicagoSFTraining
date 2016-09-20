using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Frontend.Navigation.Mvc.Models;

namespace SitefinityWebApp.Mvc.ViewModels
{
    public class CustomNodeViewModel : NodeViewModel
    {
        public CustomNodeViewModel() : base()
        {
            this.rating = this.GetRating();
        }

        public CustomNodeViewModel(SiteMapNode node, string url, string target, bool isCurrentlyOpened, bool hasChildOpen)
            : base(node, url, target, isCurrentlyOpened, hasChildOpen)
        {
            this.rating = this.GetRating();
        }

        public int Rating
        {
            get
            {
                return this.rating;
            }
        }

        private int GetRating()
        {
            int randomRating = random.Next(1, 10);

            return randomRating;
        }

        private readonly int rating;
        private static Random random = new Random();
    }
}
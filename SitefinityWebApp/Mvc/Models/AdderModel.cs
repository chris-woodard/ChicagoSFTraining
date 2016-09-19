using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Mvc.Models
{
    public class AdderModel
    {
        public AdderModel(int A, int B)
        {
            this.A = A;
            this.B = B;
            this.Sum = A + B;
        }
        public int A { get; set; }
        public int B { get; set; }
        public int Sum { get; set; }
    }
}
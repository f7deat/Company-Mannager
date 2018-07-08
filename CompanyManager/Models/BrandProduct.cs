using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyManager.Models
{
    public class BrandProduct
    {
        public int BrandProductID { get; set; }
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public int ProductID { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Product Product { get; set; }
    }
}
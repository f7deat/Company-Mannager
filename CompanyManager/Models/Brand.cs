using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyManager.Models
{
    public class Brand
    {
        public int BrandID { get; set; }
        [Display(Name ="Hãng")]
        public string BrandName { get; set; }

        public virtual ICollection<BrandProduct> BrandProducts { get; set; }
    }
}
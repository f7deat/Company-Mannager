using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyManager.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public virtual ICollection<SupplierDetail> SupplierDetails { get; set; }
    }
}
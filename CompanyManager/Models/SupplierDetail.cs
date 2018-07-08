using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompanyManager.Models
{
    public class SupplierDetail
    {
        [Key]
        public int SupplierDetailID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public int UserID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime SupplierDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
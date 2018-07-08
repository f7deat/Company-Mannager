using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyManager.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public Nullable<int> ShipperID { get; set; }
        public int ProductID { get; set; }
        public DateTime OrderDate { get; set; }
        public Nullable<int> ShippedDate { get; set; }
        public decimal ShipCod { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public int Status { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
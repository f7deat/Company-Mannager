using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyManager.Models
{
    public class Shipper
    {
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
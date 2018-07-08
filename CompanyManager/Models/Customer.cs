using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyManager.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Display(Name ="Công ty")]
        public string CompanyName { get; set; }
        [Display(Name = "Người liên hệ")]
        public string ContactName { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        public string Fax { get; set; }


        public virtual ICollection<Volume> Volumes { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
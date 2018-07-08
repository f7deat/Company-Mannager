using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyManager.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int VolumeID { get; set; }
        [Display(Name = "Mã hiệu")]
        public string ModemID { get; set; }
        [Display(Name = "Hãng")]
        public string BrandName { get; set; }
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
        [Display(Name = "Đơn vị")]
        public string Unit { get; set; }
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        public virtual Product Product { get; set; }
        public virtual Modem Modem { get; set; }
        public virtual Volume Volume { get; set; }
    }
}
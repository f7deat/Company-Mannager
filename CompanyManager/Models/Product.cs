using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyManager.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Display(Name ="Tên vật tư")]
        public string ProductName { get; set; }
        [Display(Name = "Chi tiết vật tư")]
        public string ProductContent { get; set; }
        [Display(Name = "Tồn kho")]
        public int UnitStock { get; set; }
        [Display(Name = "Ảnh")]
        public string Image { get; set; }
        [Display(Name = "Ngày cập nhật")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public virtual ICollection<Modem> Modems { get; set; }
        public ICollection<Brand> Brands { get; set; }
        public virtual ICollection<SupplierDetail> SupplierDetails { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
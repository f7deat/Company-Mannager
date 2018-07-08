using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompanyManager.Models
{
    public class Volume
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VolumeID { get; set; }
        [Display(Name = "Số")]
        public string VolumeName { get; set; }
        [Display(Name = "Ngày")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreate { get; set; }
        [Display(Name ="Địa chỉ giao hàng")]
        public string ShipAddress { get; set; }
        public int UserID { get; set; }
        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual User User { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
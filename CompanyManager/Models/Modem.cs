using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompanyManager.Models
{
    public class Modem
    {
        [Key]
        [Display(Name ="Mã hiệu")]
        public string ModemID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }
        [Display(Name = "Đơn giá")]
        public string UnitPrice { get; set; }

        public virtual Product Product { get; set; }
    }
}
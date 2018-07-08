using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyManager.Models.ViewModel
{
    public class VolumeIndexData
    {
        public int VolumeID { get; set; }
        [Display(Name = "Số")]
        public string VolumeName { get; set; }
        [Display(Name = "Ngày")]
        public DateTime DateCreate { get; set; }
        public string CompanyName { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public string Note { get; set; }
        public int UserID { get; set; }
        public int CustomerID { get; set; }
        public string Username { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyManager.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Display(Name ="Tài khoản")]
        public string Username { get; set; }
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Display(Name = "Họ tên")]
        public string FullName { get; set; }
        [Display(Name = "Giới tính")]
        public bool Gender { get; set; }
        [Display(Name = "Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Birthday { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "SĐT")]
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        [Display(Name = "Ngày tuyển dụng")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> HireDate { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }
        [Display(Name = "Trạng thái")]
        public int Status { get; set; }
        public int RoleID { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Volume> Volumes { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<SupplierDetail> SupplierDetails { get; set; }
    }
}
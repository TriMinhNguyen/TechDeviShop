namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Display(Name = "Mã tài khoản")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên tài khoản")]
        [Display(Name = "Tên tài khoản")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [StringLength(32)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên người dùng")]
        [Display(Name = "Tên người dùng")]
        [StringLength(250)]
        public string Name { get; set; }

        [Display(Name = "Giới tính")]
        public bool? Gender { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(250)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Email")]
        [Display(Name = "Email")]
        [StringLength(250)]
        public string Email { get; set; }

        [Display(Name = "Điện thoại")]
        [StringLength(50)]
        public string Phone { get; set; }

        [Display(Name = "Ảnh đại diện")]
        [StringLength(250)]
        public string Avatar { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Ngày sửa chữa")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Phân quyền")]
        public byte RoleID { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool IsActive { get; set; }

        public virtual Role Role { get; set; }
    }
}

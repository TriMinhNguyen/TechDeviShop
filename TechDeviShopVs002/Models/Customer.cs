namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [Display(Name = "Mã KH")]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập email khách hàng")]
        [Display(Name = "Email khách hàng")]
        [StringLength(250)]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [StringLength(32)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên khách hàng")]
        [Display(Name = "Tên khách hàng")]
        [StringLength(250)]
        public string CustomerName { get; set; }

        [Display(Name = "Ảnh đại diện")]
        [StringLength(250)]
        public string Avatar { get; set; }

        [Display(Name = "Giới tính")]
        public bool? CustomerGender { get; set; }

        [Display(Name = "Sinh nhật")]
        public DateTime? CustomerBirthday { get; set; }

        [Display(Name = "Điện thoại")]
        [StringLength(50)]
        public string CustomerPhone { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(500)]
        public string CustomerAddress { get; set; }

        [Display(Name = "Thành phố")]
        [StringLength(250)]
        public string CustomerCity { get; set; }

        [Display(Name = "Quận/Huyện")]
        [StringLength(250)]
        public string CustomerDistrict { get; set; }

        [Display(Name = "Mã bưu chính")]
        [StringLength(250)]
        public string PostCost { get; set; }

        [Display(Name = "Thông tin khác")]
        [StringLength(500)]
        public string OrtherDetail { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool? IsActive { get; set; }
    }
}

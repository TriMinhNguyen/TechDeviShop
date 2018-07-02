namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shipper")]
    public partial class Shipper
    {
        [Display(Name = "Mã người vận chuyển")]
        public int ShipperID { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập họ tên")]
        [Display(Name = "Họ và tên")]
        [StringLength(250)]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [StringLength(250)]
        public string Email { get; set; }

        [Display(Name = "Điện thoại")]
        [StringLength(50)]
        public string Phone { get; set; }

        [Display(Name = "Fax")]
        [StringLength(20)]
        public string Fax { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(500)]
        public string Address { get; set; }

        [Display(Name = "Ngày khởi tạo")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "User khởi tạo")]
        public int? CreateUser { get; set; }

        [Display(Name = "Ngày sửa đổi")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "User sửa đổi")]
        public int? ModifiedUser { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool IsActive { get; set; }
    }
}

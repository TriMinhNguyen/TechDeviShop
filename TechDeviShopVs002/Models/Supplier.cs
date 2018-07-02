namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supplier
    {
        [Display(Name = "Mã nhà cung cấp")]
        public int SupplierID { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên nhà cung cấp")]
        [Display(Name = "Tên nhà cung cấp")]
        [StringLength(250)]
        public string SupplierName { get; set; }

        [Display(Name = "Thẻ tiêu đề SEO")]
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [Display(Name = "Ảnh")]
        [StringLength(250)]
        public string Image { get; set; }

        [Display(Name = "Email hỗ trợ")]
        [StringLength(250)]
        public string EmailSupport { get; set; }

        [Display(Name = "Điện thoại")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Chi tiết")]
        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

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

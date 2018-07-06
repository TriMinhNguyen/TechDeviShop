namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        public int AboutID { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên thông tin")]
        [Display(Name = "Tên thông tin")]
        [StringLength(250)]
        public string AboutName { get; set; }

        [Display(Name = "Thẻ tiêu đề SEO")]
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Link ảnh")]
        [StringLength(250)]
        public string Image { get; set; }

        [Display(Name = "Chi tiết")]
        [StringLength(500)]
        public string Detail { get; set; }

        [StringLength(250)]
        public string MetalKeywords { get; set; }

        [StringLength(250)]
        public string MetalDescriptions { get; set; }

        [Display(Name = "Ngày khởi tạo")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Người khởi tạo")]
        public int? CreateUser { get; set; }

        [Display(Name = "Ngày sửa đổi")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Người sửa đổi")]
        public int? ModifiedUser { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool IsActive { get; set; }
    }
}

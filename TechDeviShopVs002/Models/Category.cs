namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        [Display(Name = "Mã CM")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập danh mục/loại sản phẩm")]
        [Display(Name = "Tên danh mục")]
        [StringLength(250)]
        public string CategoryName { get; set; }

        [Display(Name = "Thẻ tiêu đề SEO")]
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [Display(Name = "Danh mục cha")]
        public int? ParentID { get; set; }

        [Display(Name = "Thứ tự hiển thị")]
        public int? DisplayOrder { get; set; }

        [Display(Name = "Thẻ tiêu đề")]
        [StringLength(250)]
        public string SeoTitle { get; set; }

        [Display(Name = "Ngày khởi tạo")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "User khởi tạo")]
        public int? CreateUser { get; set; }

        [Display(Name = "Ngày sửa chữa")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "User sửa chữa")]
        public int? ModifiedUser { get; set; }

        [Display(Name = "Thẻ từ khóa SEO")]
        [StringLength(250)]
        public string MetalKeywords { get; set; }

        [Display(Name = "Thẻ mô tả SEO")]
        [StringLength(250)]
        public string MetalDescriptions { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool? IsActive { get; set; }

        [Display(Name = "Gắn lên trang chủ?")]
        public bool? ShowOnHome { get; set; }
    }
}

namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ArticleCategory")]
    public partial class ArticleCategory
    {
        [Display(Name = "Mã CMBV")]
        public int ArticleCategoryID { get; set; }

        [Required(ErrorMessage = "Bạn phải thêm danh mục lĩnh vực/chuyên mục bài viết")]
        [Display(Name = "Tên CMBV")]
        [StringLength(50)]
        public string ArticleCategoryName { get; set; }

        [Display(Name = "Miêu tả")]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Ảnh")]
        [StringLength(250)]
        public string Image { get; set; }

        [Display(Name = "Thẻ tiêu đề SEO")]
        [StringLength(50)]
        public string MetaTitle { get; set; }

        [Display(Name = "Chuyên mục cha")]
        public int? ParentID { get; set; }

        [Display(Name = "Thứ tự hiển thị")]
        public int? DisplayOrder { get; set; }

        [Display(Name = "Thẻ tiêu đề")]
        [StringLength(250)]
        public string SeoTitle { get; set; }

        [Display(Name = "Thể miêu tả SEO")]
        [StringLength(500)]
        public string MetaDescription { get; set; }

        [Display(Name = "Thẻ từ khóa SEO")]
        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [Display(Name = "Ngày khởi tạo")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "User khởi tạo")]
        public int? CreateUser { get; set; }

        [Display(Name = "Ngày sửa chữa")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "User sửa chữa")]
        public int? ModifiedUser { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool IsActive { get; set; }
    }
}

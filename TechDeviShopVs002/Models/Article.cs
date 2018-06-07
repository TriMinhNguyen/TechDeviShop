namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Article")]
    public partial class Article
    {
        [Display(Name = "Mã bài viết")]
        public int ArticleID { get; set; }

        [Display(Name = "Chuyên mục bài viết")]
        public int ArticleCategoryID { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tiêu đề bài viết")]
        [Display(Name = "Tiêu đề")]
        [StringLength(500)]
        public string Title { get; set; }

        [Display(Name = "Thẻ tiêu đề SEO")]
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [Display(Name = "Nội dung bài viết")]
        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Bạn phải nhập nội dung bài viết")]
        public string ArticleContent { get; set; }

        [Display(Name = "Ảnh")]
        [StringLength(250)]
        public string Image { get; set; }

        [Display(Name = "Tag")]
        [StringLength(500)]
        public string Tag { get; set; }

        [Display(Name = "Số lượng xem")]
        public int? ViewCount { get; set; }

        [Display(Name = "phiếu bầu")]
        public int? Votes { get; set; }

        [Display(Name = "Đánh giá")]
        public int? TotalRating { get; set; }

        [Display(Name = "Phê duyệt")]
        public bool? Approved { get; set; }

        [Display(Name = "User phê duyệt")]
        public int? ApprovedUser { get; set; }

        [Display(Name = "Ngày phê duyệt")]
        public DateTime? ApprovedDate { get; set; }

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

        [Display(Name = "Thẻ miêu tả SEO")]
        [StringLength(250)]
        public string MetalDescriptions { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool? IsActive { get; set; }

        public virtual ArticleCategory ArticleCategory { get; set; } 
    }
}

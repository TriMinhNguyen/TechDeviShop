namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ArticleImage")]
    public partial class ArticleImage
    {
        [Display(Name = "Mã ảnh bài viết")]
        public int ArticleImageID { get; set; }

        [Display(Name = "Bài viết")]
        public int ArticleID { get; set; }

        [Display(Name = "Thẻ tiêu đề SEO")]
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [Display(Name = "Miêu tả")]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Ảnh")]
        [StringLength(250)]
        public string Image { get; set; }

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

        public virtual Article Article { get; set; } 
    }
}

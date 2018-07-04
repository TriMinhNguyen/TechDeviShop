namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        [Display(Name = "Mã bình luận")]
        public int CommentID { get; set; }

        [Display(Name = "Bài viết")]
        public int? ArticleID { get; set; }

        [Display(Name = "Sản phẩm")]
        public int? ProductID { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [Display(Name = "Email")]
        [StringLength(250)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Tên người bình luận không được để trống")]
        [Display(Name = "Tên người bình luận")]
        [StringLength(250)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nội dung bình luận không được để trống")]
        [Display(Name = "Nội dung bình luận")]
        [StringLength(500)]
        public string CommentContent { get; set; }

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

        public virtual Product Product { get; set; }
    }
}

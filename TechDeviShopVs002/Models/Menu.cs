namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        [Display(Name = "Mã menu")]
        public int MenuID { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập nội dung menu")]
        [Display(Name = "Nội dung menu")]
        [StringLength(50)]
        public string Text { get; set; }

        [Display(Name = "Url liên kết")]
        [StringLength(250)]
        public string Link { get; set; }

        [Display(Name = "Thứ tự hiển thị")]
        public int? DisplayOrder { get; set; }

        [Display(Name = "Mục tiêu")]
        [StringLength(250)]
        public string Target { get; set; }

        [Display(Name = "Menu cha")]
        public int? ParentID { get; set; }

        [Display(Name = "Kiểu menu")]
        public int? MenuTypeID { get; set; }

        public virtual MenuType MenuType { get; set; }
    }
}

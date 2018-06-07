namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuType")]
    public partial class MenuType
    {
        [Display(Name = "Mã kiểu menu")]
        public int MenuTypeID { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên kiểu menu")]
        [Display(Name = "Tên kiểu menu")]
        [StringLength(250)]
        public string Name { get; set; }
    }
}

namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShippingMethod")]
    public partial class ShippingMethod
    {
        [Display(Name = "Mã PTGH")]
        public int ShippingMethodID { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tiêu đề phương thức giao hàng")]
        [Display(Name = "Tiêu đề phương thức giao hàng")]
        [StringLength(250)]
        public string Title { get; set; }

        [Display(Name = "Giá giao hàng")]
        public decimal? Price { get; set; }

        [Display(Name = "Ngày khởi tạo")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Ngày sửa chữa")]
        public DateTime? ModifiedDate { get; set; }
    }
}

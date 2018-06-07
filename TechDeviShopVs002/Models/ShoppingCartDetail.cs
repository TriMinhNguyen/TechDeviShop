namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShoppingCartDetail
    {
        [Display(Name = "Mã CTGH")]
        public int ShoppingCartDetailID { get; set; }

        [Display(Name = "Mã GH")]
        public int ShoppingCartID { get; set; }

        [Display(Name = "Mã SP")]
        public int ProductID { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [StringLength(250)]
        public string ProductName { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }

        [Display(Name = "Giá khuyến mãi")]
        public decimal? PromotionPrice { get; set; }

        [Display(Name = "Ngày khởi tạo")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "User khởi tạo")]
        public int? CreateUser { get; set; }

        [Display(Name = "Ngày sửa chữa")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "User sửa chữa")]
        public int? ModifiedUser { get; set; }

        public virtual Product Product { get; set; }
    }
}

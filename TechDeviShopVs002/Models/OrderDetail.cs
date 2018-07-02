namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        [Display(Name = "Mã CTĐH")]
        public int OrderDetailID { get; set; }

        [Display(Name = "Mã ĐH")]
        public int OrderID { get; set; }

        [Display(Name = "Mã SP")]
        public int ProductID { get; set; }

        [Display(Name = "Tên SP")]
        [StringLength(250)]
        public string ProductName { get; set; }

        [Display(Name = "Mã SKU")]
        [StringLength(10)]
        public string ProductCode { get; set; }

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

        [Display(Name = "Kích hoạt")]
        public bool IsActive { get; set; }

        public virtual Product Product { get; set; }
    }
}

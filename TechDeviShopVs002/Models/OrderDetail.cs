namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        public int OrderDetailID { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        [StringLength(250)]
        public string ProductName { get; set; }

        [StringLength(10)]
        public string ProductCode { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? Quantity { get; set; }

        public decimal? PromotionPrice { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public virtual Product Product { get; set; }
    }
}

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
        public int ShippingMethodID { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        public decimal? Price { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}

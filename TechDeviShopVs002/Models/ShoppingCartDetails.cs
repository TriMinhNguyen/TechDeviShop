namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShoppingCartDetails
    {
        [Key]
        public int ShoppingCartDetailID { get; set; }

        public int? ShoppingCartID { get; set; }

        public int? ProductID { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? Quantity { get; set; }

        public DateTime? CreateDate { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}

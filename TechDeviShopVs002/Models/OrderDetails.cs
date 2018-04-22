namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetails
    {
        [Key]
        public int OrderDetailID { get; set; }

        public int? OrderID { get; set; }

        public int? ProductID { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? Quantity { get; set; }

        public virtual Orders Orders { get; set; }
    }
}

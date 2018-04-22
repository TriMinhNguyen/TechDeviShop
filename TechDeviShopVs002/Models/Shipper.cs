namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shipper")]
    public partial class Shipper
    {
        public int ShipperID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [Column(TypeName = "ntext")]
        public string CusReviews { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? Status { get; set; }
    }
}

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

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string Fax { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}

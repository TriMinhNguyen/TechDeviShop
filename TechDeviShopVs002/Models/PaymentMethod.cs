namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaymentMethod")]
    public partial class PaymentMethod
    {
        public int PaymentMethodID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Note { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}

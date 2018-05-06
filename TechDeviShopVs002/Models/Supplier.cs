namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supplier
    {
        public int SupplierID { get; set; }

        [Required]
        [StringLength(250)]
        public string SupplierName { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        public string EmailSupport { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}

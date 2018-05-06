namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        public int CategoryID { get; set; }

        [Required]
        [StringLength(250)]
        public string CategoryName { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public int? ParentID { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetalKeywords { get; set; }

        [StringLength(250)]
        public string MetalDescriptions { get; set; }

        public bool? IsActive { get; set; }

        public bool? ShowOnHome { get; set; }
    }
}

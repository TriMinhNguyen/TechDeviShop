namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Footer")]
    public partial class Footer
    {
        public int FooterID { get; set; }

        public string Content { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? IsActive { get; set; }
    }
}

namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tag")]
    public partial class Tag
    {
        public int TagID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}

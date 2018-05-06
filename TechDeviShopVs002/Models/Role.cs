namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte RoleID { get; set; }

        [Required]
        [StringLength(250)]
        public string RoleName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}

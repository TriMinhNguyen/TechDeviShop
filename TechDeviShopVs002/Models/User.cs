namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }

        public int? CustomerID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public bool? Gender { get; set; }

        public DateTime? Birthday { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public byte? RoleID { get; set; }

        public bool? IsActive { get; set; }

        public virtual Role Role { get; set; }

        public virtual Customer Customer { get; set; }
    }
}

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
        [Display(Name = "Mã phân quyền")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte RoleID { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên phân quyền")]
        [Display(Name = "Tên phân quyền")]
        [StringLength(250)]
        public string RoleName { get; set; }

        [Display(Name = "Miêu tả")]
        [StringLength(500)]
        public string Description { get; set; }
    }
}

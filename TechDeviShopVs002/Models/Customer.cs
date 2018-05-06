namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        public int CustomerID { get; set; }

        [Required]
        [StringLength(250)]
        public string CustomerName { get; set; }

        public bool? CustomerGender { get; set; }

        public DateTime? CustomerBirthday { get; set; }

        [StringLength(50)]
        public string CustomerPhone { get; set; }

        [StringLength(250)]
        public string CustomerEmail { get; set; }

        [StringLength(500)]
        public string CustomerAddress { get; set; }

        [StringLength(250)]
        public string CustomerCity { get; set; }

        [StringLength(250)]
        public string CustomerDistrict { get; set; }

        [StringLength(250)]
        public string PostCost { get; set; }

        [StringLength(500)]
        public string OrtherDetail { get; set; }

        public bool? IsActive { get; set; }
    }
}

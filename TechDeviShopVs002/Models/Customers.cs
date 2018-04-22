namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customers
    {
        [Key]
        public int CustomerID { get; set; }

        [StringLength(250)]
        public string CustomerName { get; set; }

        public bool? CustomerGender { get; set; }

        public DateTime? CustomerBirthday { get; set; }

        [StringLength(250)]
        public string CustomerAddress { get; set; }

        [StringLength(250)]
        public string CustomerEmail { get; set; }

        [StringLength(50)]
        public string CustomerPhone { get; set; }

        [Column(TypeName = "ntext")]
        public string OrtherDetail { get; set; }
    }
}

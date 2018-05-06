namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        public int PaymentID { get; set; }

        public int OrderID { get; set; }

        public int PaymentMethodID { get; set; }

        public int PaymentStatusID { get; set; }

        public DateTime? PaymentDate { get; set; }

        public decimal? TotalPrice { get; set; }

        [StringLength(250)]
        public string Note { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string TransactionID { get; set; }

        [StringLength(250)]
        public string TrackingID { get; set; }

        public bool? IsActive { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }

        public virtual PaymentStatu PaymentStatus { get; set; }
    }
}

namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        [Key]
        public int OrderID { get; set; }

        public int? CustomerID { get; set; }

        public int? ShipperID { get; set; }

        public int? ShippingMethodID { get; set; }

        public decimal? ShippingCost { get; set; }

        public decimal? SubTotal { get; set; }

        public decimal? TotalPrice { get; set; }

        [StringLength(250)]
        public string CusName { get; set; }

        [StringLength(50)]
        public string CusPhone { get; set; }

        [StringLength(250)]
        public string CusEmail { get; set; }

        [StringLength(250)]
        public string Company { get; set; }

        [StringLength(250)]
        public string City { get; set; }

        [StringLength(250)]
        public string District { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(50)]
        public string ShippingPostalCode { get; set; }

        [Column(TypeName = "ntext")]
        public string OrtherNote { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        [StringLength(250)]
        public string TransactionID { get; set; }

        [StringLength(250)]
        public string TrackingID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public virtual ShippingMethod ShippingMethod { get; set; }
    }
}

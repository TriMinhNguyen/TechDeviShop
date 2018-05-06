namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int OrderID { get; set; }

        public int UserID { get; set; }

        public int CustomerID { get; set; }

        public int? ShipperID { get; set; }

        public int? ShippingMethodID { get; set; }

        public byte OrderStatusID { get; set; }

        public decimal? ShippingCost { get; set; }

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

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(50)]
        public string ShippingPostalCode { get; set; }

        [StringLength(500)]
        public string OrtherNote { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public bool? IsActive { get; set; }

        public virtual User User { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Shipper Shipper { get; set; }

        public virtual ShippingMethod ShippingMethod { get; set; }

        public virtual OrderStatu OrderStatus { get; set; }
    }
}

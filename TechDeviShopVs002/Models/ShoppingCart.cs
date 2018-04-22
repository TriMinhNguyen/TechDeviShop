namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShoppingCart")]
    public partial class ShoppingCart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShoppingCart()
        {
            ShoppingCartDetails = new HashSet<ShoppingCartDetails>();
        }

        public int ShoppingCartID { get; set; }

        public int? ShippingMethodID { get; set; }

        public decimal? ShippingCost { get; set; }

        public decimal? SubTotal { get; set; }

        public decimal? TotalPrice { get; set; }

        public DateTime? CreateDate { get; set; }

        public virtual ShippingMethod ShippingMethod { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingCartDetails> ShoppingCartDetails { get; set; }
    }
}

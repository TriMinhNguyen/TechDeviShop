namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [Display(Name = "Mã ĐH")]
        public int OrderID { get; set; }
        
        [Display(Name = "Mã khách hàng")]
        public int CustomerID { get; set; }

        [Display(Name = "Mã shipper")]
        public int? ShipperID { get; set; }

        [Display(Name = "Mã PTGH")]
        public int? ShippingMethodID { get; set; }

        [Display(Name = "Tình trạng đơn hàng")]
        public byte OrderStatusID { get; set; }

        [Display(Name = "Phí vận chuyển")]
        public decimal? ShippingCost { get; set; }

        [Display(Name = "Tên khách hàng")]
        [StringLength(250)]
        public string CusName { get; set; }

        [Display(Name = "Điện thoại khách hàng")]
        [StringLength(50)]
        public string CusPhone { get; set; }

        [Display(Name = "Email khách hàng")]
        [StringLength(250)]
        public string CusEmail { get; set; }

        [Display(Name = "Công ty")]
        [StringLength(250)]
        public string Company { get; set; }

        [Display(Name = "Thành phố")]
        [StringLength(250)]
        public string City { get; set; }

        [Display(Name = "Quận/Huyện")]
        [StringLength(250)]
        public string District { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(500)]
        public string Address { get; set; }

        [Display(Name = "Mã Bưu chính vận chuyển")]
        [StringLength(50)]
        public string ShippingPostalCode { get; set; }

        [Display(Name = "Ghi chú khác")]
        [StringLength(500)]
        public string OrtherNote { get; set; }

        [Display(Name = "Ngày tạo đơn hàng")]
        public DateTime? OrderDate { get; set; }

        [Display(Name = "Ngày bắt đầu giao hàng")]
        public DateTime? ShippedDate { get; set; }

        [Display(Name = "Hạn yêu cầu giao hàng")]
        public DateTime? RequiredDate { get; set; }

        [Display(Name = "Ngày khởi tạo")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "User khởi tạo")]
        public int? CreateUser { get; set; }

        [Display(Name = "Ngày sửa chữa")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "User sửa chữa")]
        public int? ModifiedUser { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool? IsActive { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Shipper Shipper { get; set; }

        public virtual ShippingMethod ShippingMethod { get; set; }

        public virtual OrderStatu OrderStatus { get; set; }
    }
}

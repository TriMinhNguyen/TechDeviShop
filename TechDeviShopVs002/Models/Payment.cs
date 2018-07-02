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
        [Display(Name = "Mã TT")]
        public int PaymentID { get; set; }

        [Display(Name = "Mã hóa đơn")]
        public int OrderID { get; set; }

        [Display(Name = "Phương thức thanh toán")]
        public int PaymentMethodID { get; set; }

        [Display(Name = "Trạng thái thanh toán")]
        public int PaymentStatusID { get; set; }

        [Display(Name = "Ngày thanh toán")]
        public DateTime? PaymentDate { get; set; }

        [Display(Name = "Tổng tiền")]
        public decimal? TotalPrice { get; set; }

        [Display(Name = "Ghi chú")]
        [StringLength(250)]
        public string Note { get; set; }

        [Display(Name = "Ngày khởi tạo")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "User khởi tạo")]
        public int? CreateUser { get; set; }

        [Display(Name = "Ngày sửa chữa")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "User sửa chữa")]
        public int? ModifiedUser { get; set; }

        [Display(Name = "Mã giao dịch")]
        [StringLength(250)]
        public string TransactionID { get; set; }

        [Display(Name = "Mã theo dõi")]
        [StringLength(250)]
        public string TrackingID { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool IsActive { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }

        public virtual PaymentStatu PaymentStatus { get; set; }
    }
}

namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaymentMethod")]
    public partial class PaymentMethod
    {
        [Display(Name = "Mã PTTT")]
        public int PaymentMethodID { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên phương thức thanh toán")]
        [Display(Name = "Tên PTTT")]
        [StringLength(250)]
        public string Name { get; set; }

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

        [Display(Name = "Kích hoạt")]
        public bool? IsActive { get; set; }
    }
}

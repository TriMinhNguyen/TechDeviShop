namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PaymentStatu
    {
        [Key]
        [Display(Name = "Mã TTTT")]
        public int PaymentStatusID { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên trạng thái thanh toán")]
        [Display(Name = "Tên TTTT")]
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
        public bool IsActive { get; set; }
    }
}

namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderStatu
    {
        [Key]
        [Display(Name = "Mã TTĐH")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte OrderStatusID { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên tình trạng đơn hàng")]
        [Display(Name = "Tên TTĐH")]
        [StringLength(250)]
        public string OrderStatusName { get; set; }

        [Display(Name = "Miêu tả")]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Thứ tự sắp xếp")]
        public int? DisplayOrder { get; set; }

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

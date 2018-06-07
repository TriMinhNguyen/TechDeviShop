namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [Display(Name = "Mã SP")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        [Display(Name = "Tên SP")]
        [StringLength(250)]
        public string ProductName { get; set; }

        [Display(Name = "Mã SKU")]
        [StringLength(10)]
        public string ProductCode { get; set; }

        [Display(Name = "Thẻ tiêu đề SEO")]
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [Display(Name = "Miêu tả")]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Ảnh")]
        [StringLength(250)]
        public string Image { get; set; }

        [Display(Name = "Ảnh khác")]
        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }

        [Display(Name = "Giá bán")]
        public decimal? Price { get; set; }

        [Display(Name = "Giá khuyến mại")]
        public decimal? PromotionPrice { get; set; }

        [Display(Name = "Đã tính VAT?")]
        public bool? IncludeVAT { get; set; }

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        [Display(Name = "Nhà cung cấp")]
        public int? SupplierID { get; set; }

        [Display(Name = "Thể loại")]
        public int? CategoryID { get; set; }

        [Display(Name = "Bảo hành")]
        public int? Warranty { get; set; }

        [Display(Name = "Ngày khởi tạo")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "User khởi tạo")]
        public int? CreateUser { get; set; }

        [Display(Name = "Ngày sửa chữa")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "User sửa chữa")]
        public int? ModifiedUser { get; set; }

        [Display(Name = "Thẻ từ khóa SEO")]
        [StringLength(250)]
        public string MetalKeywords { get; set; }

        [Display(Name = "Thẻ tóm tắt nội dung SEO")]
        [StringLength(250)]
        public string MetalDescriptions { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool? IsActive { get; set; }

        public DateTime? TopHot { get; set; }

        [Display(Name = "Số lượng xem")]
        public int? ViewCount { get; set; }

        [StringLength(250)]
        public string CpuChip { get; set; }

        [StringLength(250)]
        public string CpuType { get; set; }

        [StringLength(250)]
        public string CpuSpeed { get; set; }

        [StringLength(250)]
        public string CpuMaxSpeed { get; set; }

        [StringLength(250)]
        public string BusSpeed { get; set; }

        [StringLength(250)]
        public string Ram { get; set; }

        [StringLength(250)]
        public string RamType { get; set; }

        [StringLength(250)]
        public string BusRamSpeed { get; set; }

        [StringLength(250)]
        public string MaxRam { get; set; }

        [Display(Name = "Ổ cứng")]
        [StringLength(250)]
        public string HardDrive { get; set; }

        [Display(Name = "Kích thước")]
        [StringLength(250)]
        public string Size { get; set; }

        [Display(Name = "Trọng lượng")]
        [StringLength(250)]
        public string Weight { get; set; }

        [Display(Name = "Màu sắc")]
        [StringLength(250)]
        public string Color { get; set; }

        [Display(Name = "Nguyên liệu")]
        [StringLength(250)]
        public string Material { get; set; }

        [Display(Name = "Kích thước màn hình")]
        [StringLength(250)]
        public string ScreenSize { get; set; }

        [Display(Name = "Độ phân giải")]
        [StringLength(250)]
        public string Resolution { get; set; }

        [Display(Name = "Công nghệ màn hình")]
        [StringLength(250)]
        public string ScreenTechnology { get; set; }

        [Display(Name = "Màn hình cảm ứng")]
        [StringLength(250)]
        public string TouchScreen { get; set; }

        [Display(Name = "Card đồ họa")]
        [StringLength(250)]
        public string GraphicsCard { get; set; }

        [Display(Name = "Âm thanh")]
        [StringLength(250)]
        public string Sound { get; set; }

        [Display(Name = "Cổng kết nối")]
        [StringLength(250)]
        public string ConnectionPort { get; set; }

        [Display(Name = "Kết nối không dây")]
        [StringLength(250)]
        public string WirelessConnection { get; set; }

        [Display(Name = "Ổ cắm thẻ nhớ")]
        [StringLength(250)]
        public string MemoryCardSlot { get; set; }

        [Display(Name = "Ổ đĩa quang")]
        [StringLength(250)]
        public string OpticalDiskDrive { get; set; }

        [Display(Name = "Webcam")]
        [StringLength(250)]
        public string Webcam { get; set; }

        [Display(Name = "Đèn bàn phím")]
        [StringLength(250)]
        public string KeyboardLights { get; set; }

        [Display(Name = "Kiểu pin")]
        [StringLength(250)]
        public string PinType { get; set; }

        [Display(Name = "Pin")]
        [StringLength(250)]
        public string Pin { get; set; }

        [Display(Name = "Hệ điều hành")]
        [StringLength(250)]
        public string OperatingSystem { get; set; }

        [Display(Name = "Thông tin khác")]
        [Column(TypeName = "ntext")]
        public string OtherInfo { get; set; }

        public virtual Category Category { get; set; }

        public virtual Supplier Suppliers { get; set; }
    }
}

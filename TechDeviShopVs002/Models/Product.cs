namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public int ProductID { get; set; }

        [Required]
        [StringLength(250)]
        public string ProductName { get; set; }

        [StringLength(10)]
        public string ProductCode { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public bool? IncludeVAT { get; set; }

        public int Quantity { get; set; }

        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }

        public int? Warranty { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetalKeywords { get; set; }

        [StringLength(250)]
        public string MetalDescriptions { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? TopHot { get; set; }

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

        [StringLength(250)]
        public string HardDrive { get; set; }

        [StringLength(250)]
        public string Size { get; set; }

        [StringLength(250)]
        public string Weight { get; set; }

        [StringLength(250)]
        public string Color { get; set; }

        [StringLength(250)]
        public string Material { get; set; }

        [StringLength(250)]
        public string ScreenSize { get; set; }

        [StringLength(250)]
        public string Resolution { get; set; }

        [StringLength(250)]
        public string ScreenTechnology { get; set; }

        [StringLength(250)]
        public string TouchScreen { get; set; }

        [StringLength(250)]
        public string GraphicsCard { get; set; }

        [StringLength(250)]
        public string Sound { get; set; }

        [StringLength(250)]
        public string ConnectionPort { get; set; }

        [StringLength(250)]
        public string WirelessConnection { get; set; }

        [StringLength(250)]
        public string MemoryCardSlot { get; set; }

        [StringLength(250)]
        public string OpticalDiskDrive { get; set; }

        [StringLength(250)]
        public string Webcam { get; set; }

        [StringLength(250)]
        public string KeyboardLights { get; set; }

        [StringLength(250)]
        public string PinType { get; set; }

        [StringLength(250)]
        public string Pin { get; set; }

        [StringLength(250)]
        public string OperatingSystem { get; set; }

        [Column(TypeName = "ntext")]
        public string OtherInfo { get; set; }

        public virtual Category Category { get; set; }

        public virtual Supplier Suppliers { get; set; }
    }
}

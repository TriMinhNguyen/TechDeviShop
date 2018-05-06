namespace TechDeviShopVs002.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TechDeviShopDBContext : DbContext
    {
        public TechDeviShopDBContext()
            : base("name=TechDeviShopDBContext")
        {
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ContentTag> ContentTags { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatu> OrderStatus { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<PaymentStatu> PaymentStatus { get; set; }
        public virtual DbSet<ProductContent> ProductContents { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<ShippingMethod> ShippingMethods { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ShoppingCartDetail> ShoppingCartDetails { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.ProductCode)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.ShippingCost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Payment>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ProductContent>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductCode)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ShippingMethod>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ShoppingCartDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ShoppingCartDetail>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}

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

        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Footer> Footer { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuType> MenuType { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductContent> ProductContent { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Shipper> Shipper { get; set; }
        public virtual DbSet<ShippingMethod> ShippingMethod { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<ShoppingCartDetails> ShoppingCartDetails { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<SystemConfig> SystemConfig { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.FooterID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetails>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Orders>()
                .Property(e => e.ShippingCost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Orders>()
                .Property(e => e.SubTotal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Orders>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

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

            modelBuilder.Entity<ProductContent>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<ProductContent>()
                .HasMany(e => e.Tag1)
                .WithMany(e => e.ProductContent)
                .Map(m => m.ToTable("ContentTag").MapLeftKey("ProductContentID").MapRightKey("TagID"));

            modelBuilder.Entity<Role>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ShippingMethod>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ShoppingCart>()
                .Property(e => e.ShippingCost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ShoppingCart>()
                .Property(e => e.SubTotal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ShoppingCart>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ShoppingCartDetails>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Suppliers>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.SystemConfigID)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.TagID)
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

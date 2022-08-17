using ecommerceweb.SharedModel;
using Microsoft.EntityFrameworkCore;

namespace ecommerceweb.Website.Models.Context
{
    public class EcommerceWebContext : DbContext
    {
        public EcommerceWebContext()
        {
        }

        public EcommerceWebContext(DbContextOptions<EcommerceWebContext> options) : base(options)
        {
        }

        public virtual DbSet<AccountDTO> Accounts { get; set; } = null!;
        public virtual DbSet<CategoryDTO> Categories { get; set; } = null!;
        public virtual DbSet<OrderDTO> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetailDTO> OrderDetails { get; set; } = null!;
        public virtual DbSet<ProductDTO> Products { get; set; } = null!;
        public virtual DbSet<ProductImageDTO> ProductImages { get; set; } = null!;
        public virtual DbSet<RatingDTO> Ratings { get; set; } = null!;
        public virtual DbSet<TransactStatusDTO> TransactStatuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-AB57MQ4;Database=newEcommerceAPI;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId).HasColumnName("AccountID");
                entity.Property(e => e.Username).HasMaxLength(50);
                entity.Property(e => e.Fullname).HasMaxLength(150);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Password).HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(12).IsUnicode(false);
                entity.Property(e => e.Address).HasMaxLength(150);
                entity.Property(e => e.Avatar).HasMaxLength(1000);
                entity.Property(e => e.RoleId).HasColumnName("RoleID");
                entity.Property(e => e.LastLogin).HasColumnType("datetime");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.HasOne(d => d.Role).WithMany(p => p.Accounts).HasForeignKey(d => d.RoleId).HasConstraintName("FK_Accounts_Roles");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);
                entity.Property(e => e.CategoryId).HasColumnName("CatID");
                entity.Property(e => e.CategoryName).HasMaxLength(250);
                entity.Property(e => e.ParentId).HasColumnName("ParentID");
                entity.Property(e => e.Thumb).HasMaxLength(250);
                entity.Property(e => e.Title).HasMaxLength(250);
                entity.Property(e => e.Alias).HasMaxLength(250);
                entity.Property(e => e.MetaDesc).HasMaxLength(250);
                entity.Property(e => e.MetaKey).HasMaxLength(250);
                entity.Property(e => e.Cover).HasMaxLength(255);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
                entity.Property(e => e.OrderDate).HasColumnType("datetime");
                entity.Property(e => e.ShipDate).HasColumnType("datetime");
                entity.Property(e => e.PaymentDate).HasColumnType("datetime");
                entity.Property(e => e.TransactStatusId).HasColumnName("TransactStatusID");
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
                entity.Property(e => e.LocationId).HasColumnName("LocationID");
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Customers");
                entity.HasOne(d => d.TransactStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TransactStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_TransactStatus");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
                entity.Property(e => e.OrderId).HasColumnName("OrderID");
                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetails_Orders");
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_OrderDetails_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.ProductName).HasMaxLength(255);
                entity.Property(e => e.ShortDesc).HasMaxLength(255);
                entity.Property(e => e.CategoryId).HasColumnName("CatID");
                entity.Property(e => e.Thumb).HasMaxLength(255);
                entity.Property(e => e.Images).HasMaxLength(255);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Title).HasMaxLength(255);
                entity.Property(e => e.Alias).HasMaxLength(255);
                entity.Property(e => e.MetaDesc).HasMaxLength(255);
                entity.Property(e => e.MetaKey).HasMaxLength(255);
                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_Categories");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");
                entity.Property(e => e.RoleName).HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<TransactStatus>(entity =>
            {
                entity.ToTable("TransactStatus");
                entity.Property(e => e.TransactStatusId).HasColumnName("TransactStatusID");
                entity.Property(e => e.Status).HasMaxLength(50);
            });*/

            //OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            //throw new NotImplementedException();
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

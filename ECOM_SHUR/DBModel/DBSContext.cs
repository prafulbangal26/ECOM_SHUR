using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ECOM_SHUR.DBModel
{
    public partial class DBSContext : DbContext
    {
        public DBSContext()
        {
        }

        public DBSContext(DbContextOptions<DBSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryMaster> CategoryMasters { get; set; }
        public virtual DbSet<CategoryProductMapping> CategoryProductMappings { get; set; }
        public virtual DbSet<ColorMaster> ColorMasters { get; set; }
        public virtual DbSet<CouponMaster> CouponMasters { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCouponMapping> ProductCouponMappings { get; set; }
        public virtual DbSet<ProductImageConfig> ProductImageConfigs { get; set; }
        public virtual DbSet<ProductMapping> ProductMappings { get; set; }
        public virtual DbSet<ProductTagMapping> ProductTagMappings { get; set; }
        public virtual DbSet<SizeMaster> SizeMasters { get; set; }
        public virtual DbSet<TagMaster> TagMasters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=SHUR_MASTER;Trusted_Connection=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CategoryMaster>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__CATEGORY__E7DA297C453CD06E");

                entity.ToTable("CATEGORY_MASTER");

                entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");

                entity.Property(e => e.CategoryDescription)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_DESCRIPTION");

                entity.Property(e => e.CategoryMetaname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_METANAME");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_NAME");

                entity.Property(e => e.CategoryParentid).HasColumnName("CATEGORY_PARENTID");

                entity.Property(e => e.CategorySlug)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_SLUG");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");

                entity.Property(e => e.IsPublished)
                    .HasColumnName("IS_PUBLISHED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PublishedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("PUBLISHED_AT");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy).HasColumnName("UPDATED_BY");
            });

            modelBuilder.Entity<CategoryProductMapping>(entity =>
            {
                entity.ToTable("CATEGORY_PRODUCT_MAPPING");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryProductMappings)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__CATEGORY___CATEG__3D5E1FD2");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CategoryProductMappings)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__CATEGORY___PRODU__3E52440B");
            });

            modelBuilder.Entity<ColorMaster>(entity =>
            {
                entity.HasKey(e => e.ColorId)
                    .HasName("PK__COLOR_MA__630E2312401CACCB");

                entity.ToTable("COLOR_MASTER");

                entity.Property(e => e.ColorId).HasColumnName("COLOR_ID");

                entity.Property(e => e.ColorHexcode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("COLOR_HEXCODE");

                entity.Property(e => e.ColorName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("COLOR_NAME");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");

                entity.Property(e => e.IsPublished)
                    .HasColumnName("IS_PUBLISHED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PublishedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("PUBLISHED_AT");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy).HasColumnName("UPDATED_BY");
            });

            modelBuilder.Entity<CouponMaster>(entity =>
            {
                entity.ToTable("COUPON_MASTER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CouponCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COUPON_CODE");

                entity.Property(e => e.CouponDiscount)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("COUPON_DISCOUNT");

                entity.Property(e => e.CouponName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("COUPON_NAME");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");

                entity.Property(e => e.EndAt)
                    .HasColumnType("datetime")
                    .HasColumnName("END_AT");

                entity.Property(e => e.IsForSale).HasColumnName("IS_FOR_SALE");

                entity.Property(e => e.IsForShop).HasColumnName("IS_FOR_SHOP");

                entity.Property(e => e.IsPublished)
                    .HasColumnName("IS_PUBLISHED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductDescription)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_DESCRIPTION");

                entity.Property(e => e.ProductDiscount)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("PRODUCT_DISCOUNT");

                entity.Property(e => e.ProductMetaname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_METANAME");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_NAME");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("PRODUCT_PRICE");

                entity.Property(e => e.ProductQuanitity).HasColumnName("PRODUCT_QUANITITY");

                entity.Property(e => e.ProductSku)
                    .HasMaxLength(100)
                    .HasColumnName("PRODUCT_SKU");

                entity.Property(e => e.ProductSlug)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_SLUG");

                entity.Property(e => e.ProductSummery)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_SUMMERY");

                entity.Property(e => e.PublishedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("PUBLISHED_AT");

                entity.Property(e => e.StartAt)
                    .HasColumnType("datetime")
                    .HasColumnName("START_AT");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy).HasColumnName("UPDATED_BY");
            });

            modelBuilder.Entity<ProductCouponMapping>(entity =>
            {
                entity.HasKey(e => e.PcId)
                    .HasName("PK__PRODUCT___B9EB73ADB16F9AE1");

                entity.ToTable("PRODUCT_COUPON_MAPPING");

                entity.Property(e => e.PcId).HasColumnName("PC_ID");

                entity.Property(e => e.CouponId).HasColumnName("COUPON_ID");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.ProductCouponMappings)
                    .HasForeignKey(d => d.CouponId)
                    .HasConstraintName("FK__PRODUCT_C__COUPO__47DBAE45");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCouponMappings)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__PRODUCT_C__PRODU__46E78A0C");
            });

            modelBuilder.Entity<ProductImageConfig>(entity =>
            {
                entity.HasKey(e => e.PimageId)
                    .HasName("PK__PRODUCT___3E8A55EAC82D67B9");

                entity.ToTable("PRODUCT_IMAGE_CONFIG");

                entity.Property(e => e.PimageId).HasColumnName("PIMAGE_ID");

                entity.Property(e => e.Imagedata).HasColumnName("IMAGEDATA");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

                entity.Property(e => e.PsmId).HasColumnName("PSM_ID");

                entity.HasOne(d => d.Psm)
                    .WithMany(p => p.ProductImageConfigs)
                    .HasForeignKey(d => d.PsmId)
                    .HasConstraintName("FK__PRODUCT_I__PSM_I__3A81B327");
            });

            modelBuilder.Entity<ProductMapping>(entity =>
            {
                entity.HasKey(e => e.PsmId)
                    .HasName("PK__PRODUCT___3E8E9D0DCA69FF39");

                entity.ToTable("PRODUCT_MAPPING");

                entity.Property(e => e.PsmId).HasColumnName("PSM_ID");

                entity.Property(e => e.ColorId).HasColumnName("COLOR_ID");

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("DISCOUNT");

                entity.Property(e => e.IsAvailable).HasColumnName("IS_AVAILABLE");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.SizeId).HasColumnName("SIZE_ID");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.ProductMappings)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK__PRODUCT_M__COLOR__37A5467C");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductMappings)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__PRODUCT_M__PRODU__35BCFE0A");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.ProductMappings)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK__PRODUCT_M__SIZE___36B12243");
            });

            modelBuilder.Entity<ProductTagMapping>(entity =>
            {
                entity.ToTable("PRODUCT_TAG_MAPPING");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.Property(e => e.TagId).HasColumnName("TAG_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductTagMappings)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__PRODUCT_T__PRODU__412EB0B6");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ProductTagMappings)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK__PRODUCT_T__TAG_I__4222D4EF");
            });

            modelBuilder.Entity<SizeMaster>(entity =>
            {
                entity.HasKey(e => e.SizeId)
                    .HasName("PK__SIZE_MAS__694E1A7DF6740481");

                entity.ToTable("SIZE_MASTER");

                entity.Property(e => e.SizeId).HasColumnName("SIZE_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");

                entity.Property(e => e.IsPublished)
                    .HasColumnName("IS_PUBLISHED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PublishedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("PUBLISHED_AT");

                entity.Property(e => e.SizeRange)
                    .HasMaxLength(15)
                    .HasColumnName("SIZE_RANGE");

                entity.Property(e => e.SizeType)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SIZE_TYPE");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy).HasColumnName("UPDATED_BY");
            });

            modelBuilder.Entity<TagMaster>(entity =>
            {
                entity.HasKey(e => e.TagId)
                    .HasName("PK__TAG_MAST__AA26DFB1C9DF8691");

                entity.ToTable("TAG_MASTER");

                entity.Property(e => e.TagId).HasColumnName("TAG_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");

                entity.Property(e => e.IsPublished)
                    .HasColumnName("IS_PUBLISHED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PublishedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("PUBLISHED_AT");

                entity.Property(e => e.TagDescription)
                    .IsUnicode(false)
                    .HasColumnName("TAG_DESCRIPTION");

                entity.Property(e => e.TagMetaname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TAG_METANAME");

                entity.Property(e => e.TagName)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("TAG_NAME");

                entity.Property(e => e.TagSlug)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TAG_SLUG");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UpdatedBy).HasColumnName("UPDATED_BY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

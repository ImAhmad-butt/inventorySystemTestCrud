using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeInventorySystem.Models
{
    public partial class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Csptemplate> Csptemplate { get; set; }
        public virtual DbSet<CspuserTemp> CspuserTemp { get; set; }
        public virtual DbSet<Empolyee> Empolyee { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<TblPlayers> TblPlayers { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-SL9RFMF;Database=Test;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Csptemplate>(entity =>
            {
                entity.ToTable("CSPTemplate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CspxmlData).HasColumnName("CSPXmlData");
            });

            modelBuilder.Entity<CspuserTemp>(entity =>
            {
                entity.ToTable("CSPUserTemp");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CsptempId).HasColumnName("CSPTempID");

                entity.Property(e => e.CspuserXmlData).HasColumnName("CSPUserXmlData");

                entity.HasOne(d => d.Csptemp)
                    .WithMany(p => p.CspuserTemp)
                    .HasForeignKey(d => d.CsptempId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CSPUserTe__CSPTe__72C60C4A");
            });

            modelBuilder.Entity<Empolyee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Salary).HasMaxLength(50);
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .IsUnicode(false);

                entity.Property(e => e.From)
                    .HasColumnName("from")
                    .IsUnicode(false);

                entity.Property(e => e.Header)
                    .HasColumnName("header")
                    .IsUnicode(false);

                entity.Property(e => e.To)
                    .HasColumnName("to")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__B40CC6CDD94BD0B8");

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<TblPlayers>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_Players");

                entity.Property(e => e.BelongsTo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FeePerMatch).HasColumnType("numeric(16, 2)");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("PlayerID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PlayerName)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

namespace QUANLYTHUVIEN.DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ThuvienDBContext : DbContext
    {
        public ThuvienDBContext()
            : base("name=ThuvienDBContext")
        {
        }

        public virtual DbSet<DOCGIA> DOCGIA { get; set; }
        public virtual DbSet<LOAITAIKHOAN> LOAITAIKHOAN { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIEN { get; set; }
        public virtual DbSet<SACH> SACH { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOAN { get; set; }
        public virtual DbSet<PHIEUMUONSACH> PHIEUMUONSACH { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DOCGIA>()
                .Property(e => e.MADOCGIA)
                .IsUnicode(false);

            modelBuilder.Entity<DOCGIA>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<DOCGIA>()
                .HasMany(e => e.PHIEUMUONSACH)
                .WithRequired(e => e.DOCGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAITAIKHOAN>()
                .HasMany(e => e.TAIKHOAN)
                .WithRequired(e => e.LOAITAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MANHANVIEN)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUMUONSACH)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MASACH)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.PHIEUMUONSACH)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUMUONSACH>()
                .Property(e => e.MADOCGIA)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUMUONSACH>()
                .Property(e => e.MASACH)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUMUONSACH>()
                .Property(e => e.MANHANVIEN)
                .IsUnicode(false);
        }
    }
}

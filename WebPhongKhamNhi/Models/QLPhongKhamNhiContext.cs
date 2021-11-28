using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class QLPhongKhamNhiContext : DbContext
    {
        public QLPhongKhamNhiContext()
        {
        }

        public QLPhongKhamNhiContext(DbContextOptions<QLPhongKhamNhiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bacsi> Bacsis { get; set; }
        public virtual DbSet<Benhnhan> Benhnhans { get; set; }
        public virtual DbSet<Chitietdonthuoc> Chitietdonthuocs { get; set; }
        public virtual DbSet<Chitiethoadonthuoc> Chitiethoadonthuocs { get; set; }
        public virtual DbSet<Chitietphieunhap> Chitietphieunhaps { get; set; }
        public virtual DbSet<Chitietphieuxetnghiem> Chitietphieuxetnghiems { get; set; }
        public virtual DbSet<Dichvukham> Dichvukhams { get; set; }
        public virtual DbSet<Dichvuxetnghiem> Dichvuxetnghiems { get; set; }
        public virtual DbSet<Donthuoc> Donthuocs { get; set; }
        public virtual DbSet<Hoadonthuoc> Hoadonthuocs { get; set; }
        public virtual DbSet<Hosokham> Hosokhams { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<Lichsudangnhap> Lichsudangnhaps { get; set; }
        public virtual DbSet<Nhasanxuat> Nhasanxuats { get; set; }
        public virtual DbSet<Phieudangkykham> Phieudangkykhams { get; set; }
        public virtual DbSet<Phieunhap> Phieunhaps { get; set; }
        public virtual DbSet<Phieuxetnghiem> Phieuxetnghiems { get; set; }
        public virtual DbSet<Thuoc> Thuocs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-S2EN0RRO\\SQLEXPRESS01;Database=QLPhongKhamNhi;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bacsi>(entity =>
            {
                entity.HasKey(e => e.MaBacSi);

                entity.ToTable("BACSI");

                entity.Property(e => e.ChuyenMon).HasMaxLength(100);

                entity.Property(e => e.HoTen).HasMaxLength(100);

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TrinhDo).HasMaxLength(100);

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.Bacsis)
                    .HasForeignKey(d => d.MaKhoa)
                    .HasConstraintName("FK_BACSI_KHOA");
            });

            modelBuilder.Entity<Benhnhan>(entity =>
            {
                entity.HasKey(e => e.MaBenhNhan);

                entity.ToTable("BENHNHAN");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.HoTen).HasMaxLength(100);

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenNguoiThan).HasMaxLength(100);

                entity.Property(e => e.TenTaiKhoan)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Chitietdonthuoc>(entity =>
            {
                entity.HasKey(e => new { e.MaDonThuoc, e.MaThuoc });

                entity.ToTable("CHITIETDONTHUOC");

                entity.Property(e => e.HuongDanSuDung).HasMaxLength(255);

                entity.HasOne(d => d.MaDonThuocNavigation)
                    .WithMany(p => p.Chitietdonthuocs)
                    .HasForeignKey(d => d.MaDonThuoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIETDONTHUOC_DONTHUOC");

                entity.HasOne(d => d.MaThuocNavigation)
                    .WithMany(p => p.Chitietdonthuocs)
                    .HasForeignKey(d => d.MaThuoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIETDONTHUOC_THUOC");
            });

            modelBuilder.Entity<Chitiethoadonthuoc>(entity =>
            {
                entity.HasKey(e => new { e.MaHoaDonThuoc, e.MaThuoc });

                entity.ToTable("CHITIETHOADONTHUOC");

                entity.Property(e => e.Gia).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.MaHoaDonThuocNavigation)
                    .WithMany(p => p.Chitiethoadonthuocs)
                    .HasForeignKey(d => d.MaHoaDonThuoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIETHOADONTHUOC_HOADONTHUOC");

                entity.HasOne(d => d.MaThuocNavigation)
                    .WithMany(p => p.Chitiethoadonthuocs)
                    .HasForeignKey(d => d.MaThuoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIETHOADONTHUOC_THUOC");
            });

            modelBuilder.Entity<Chitietphieunhap>(entity =>
            {
                entity.HasKey(e => new { e.MaPhieuNhap, e.MaThuoc });

                entity.ToTable("CHITIETPHIEUNHAP");

                entity.Property(e => e.GiaThuoc).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.MaPhieuNhapNavigation)
                    .WithMany(p => p.Chitietphieunhaps)
                    .HasForeignKey(d => d.MaPhieuNhap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIETPHIEUNHAP_PHIEUNHAP");

                entity.HasOne(d => d.MaThuocNavigation)
                    .WithMany(p => p.Chitietphieunhaps)
                    .HasForeignKey(d => d.MaThuoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIETPHIEUNHAP_THUOC");
            });

            modelBuilder.Entity<Chitietphieuxetnghiem>(entity =>
            {
                entity.HasKey(e => new { e.MaXetNghiem, e.MaPhieuXetNghiem });

                entity.ToTable("CHITIETPHIEUXETNGHIEM");

                entity.Property(e => e.ChiPhi).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.MaPhieuXetNghiemNavigation)
                    .WithMany(p => p.Chitietphieuxetnghiems)
                    .HasForeignKey(d => d.MaPhieuXetNghiem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIETPHIEUXETNGHIEM_PHIEUXETNGHIEM");

                entity.HasOne(d => d.MaXetNghiemNavigation)
                    .WithMany(p => p.Chitietphieuxetnghiems)
                    .HasForeignKey(d => d.MaXetNghiem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIETPHIEUXETNGHIEM_DICHVUXETNGHIEM");
            });

            modelBuilder.Entity<Dichvukham>(entity =>
            {
                entity.HasKey(e => e.MaDichVu);

                entity.ToTable("DICHVUKHAM");

                entity.Property(e => e.ChiPhi).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TenDichVu).HasMaxLength(100);
            });

            modelBuilder.Entity<Dichvuxetnghiem>(entity =>
            {
                entity.HasKey(e => e.MaXetNghiem);

                entity.ToTable("DICHVUXETNGHIEM");

                entity.Property(e => e.ChiPhi).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TenXetNghiem).HasMaxLength(255);
            });

            modelBuilder.Entity<Donthuoc>(entity =>
            {
                entity.HasKey(e => e.MaDonThuoc);

                entity.ToTable("DONTHUOC");

                entity.Property(e => e.TenDonThuoc).HasMaxLength(255);

                entity.HasOne(d => d.MaHoSoNavigation)
                    .WithMany(p => p.Donthuocs)
                    .HasForeignKey(d => d.MaHoSo)
                    .HasConstraintName("FK_DONTHUOC_HOSOKHAM");
            });

            modelBuilder.Entity<Hoadonthuoc>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon);

                entity.ToTable("HOADONTHUOC");

                entity.Property(e => e.NgayThanhToan).HasColumnType("datetime");

                entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.MaBenhNhanNavigation)
                    .WithMany(p => p.Hoadonthuocs)
                    .HasForeignKey(d => d.MaBenhNhan)
                    .HasConstraintName("FK_HOADONTHUOC_BENHNHAN");
            });

            modelBuilder.Entity<Hosokham>(entity =>
            {
                entity.HasKey(e => e.MaHoSo);

                entity.ToTable("HOSOKHAM");

                entity.Property(e => e.ChuanDoan).HasMaxLength(255);

                entity.Property(e => e.TrieuChung).HasMaxLength(255);

                entity.HasOne(d => d.MaBacSiNavigation)
                    .WithMany(p => p.Hosokhams)
                    .HasForeignKey(d => d.MaBacSi)
                    .HasConstraintName("FK_HOSOKHAM_BACSI");

                entity.HasOne(d => d.MaBenhNhanNavigation)
                    .WithMany(p => p.Hosokhams)
                    .HasForeignKey(d => d.MaBenhNhan)
                    .HasConstraintName("FK_HOSOKHAM_BENHNHAN");
            });

            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(e => e.MaKhoa);

                entity.ToTable("KHOA");

                entity.Property(e => e.TenKhoa).HasMaxLength(100);
            });

            modelBuilder.Entity<Lichsudangnhap>(entity =>
            {
                entity.HasKey(e => e.MaLichSu)
                    .HasName("PK_Table_1_1");

                entity.ToTable("LICHSUDANGNHAP");

                entity.Property(e => e.ThoiGianRa).HasColumnType("datetime");

                entity.Property(e => e.ThoiGianVao).HasColumnType("datetime");

                entity.HasOne(d => d.MaBenhNhanNavigation)
                    .WithMany(p => p.Lichsudangnhaps)
                    .HasForeignKey(d => d.MaBenhNhan)
                    .HasConstraintName("FK_LICHSUKHAM_BENHNHAN");
            });

            modelBuilder.Entity<Nhasanxuat>(entity =>
            {
                entity.HasKey(e => e.MaNhaSanXuat)
                    .HasName("PK_Table_1");

                entity.ToTable("NHASANXUAT");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenNhaSanXuat).HasMaxLength(100);
            });

            modelBuilder.Entity<Phieudangkykham>(entity =>
            {
                entity.HasKey(e => e.MaPhieuDangKy);

                entity.ToTable("PHIEUDANGKYKHAM");

                entity.Property(e => e.NgayDangKy).HasColumnType("datetime");

                entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.MaBenhNhanNavigation)
                    .WithMany(p => p.Phieudangkykhams)
                    .HasForeignKey(d => d.MaBenhNhan)
                    .HasConstraintName("FK_PHIEUDANGKYKHAM_BENHNHAN");

                entity.HasOne(d => d.MaDichVuNavigation)
                    .WithMany(p => p.Phieudangkykhams)
                    .HasForeignKey(d => d.MaDichVu)
                    .HasConstraintName("FK_PHIEUDANGKYKHAM_DICHVUKHAM");
            });

            modelBuilder.Entity<Phieunhap>(entity =>
            {
                entity.HasKey(e => e.MaPhieuNhap);

                entity.ToTable("PHIEUNHAP");

                entity.Property(e => e.NgayNhap).HasColumnType("datetime");

                entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.MaNhaSanXuatNavigation)
                    .WithMany(p => p.Phieunhaps)
                    .HasForeignKey(d => d.MaNhaSanXuat)
                    .HasConstraintName("FK_PHIEUNHAP_NHASANXUAT");
            });

            modelBuilder.Entity<Phieuxetnghiem>(entity =>
            {
                entity.HasKey(e => e.MaPhieuXetNghiem);

                entity.ToTable("PHIEUXETNGHIEM");

                entity.Property(e => e.NgayThanhToan).HasColumnType("datetime");

                entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.MaHoSoNavigation)
                    .WithMany(p => p.Phieuxetnghiems)
                    .HasForeignKey(d => d.MaHoSo)
                    .HasConstraintName("FK_PHIEUXETNGHIEM_HOSOKHAM");
            });

            modelBuilder.Entity<Thuoc>(entity =>
            {
                entity.HasKey(e => e.MaThuoc);

                entity.ToTable("THUOC");

                entity.Property(e => e.Gia).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.HuongDan).HasMaxLength(255);

                entity.Property(e => e.Ten).HasMaxLength(255);

                entity.Property(e => e.ThoiDiemSua).HasColumnType("datetime");

                entity.HasOne(d => d.MaNhaSanXuatNavigation)
                    .WithMany(p => p.Thuocs)
                    .HasForeignKey(d => d.MaNhaSanXuat)
                    .HasConstraintName("FK_THUOC_NHASANXUAT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

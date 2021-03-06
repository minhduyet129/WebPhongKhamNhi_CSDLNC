// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebPhongKhamNhi.Models;

namespace WebPhongKhamNhi.Migrations
{
    [DbContext(typeof(QLPhongKhamNhiContext))]
    partial class QLPhongKhamNhiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebPhongKhamNhi.Models.Bacsi", b =>
                {
                    b.Property<int>("MaBacSi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("MaKhoa")
                        .HasColumnType("int");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength(true);

                    b.Property<string>("TrinhDo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaBacSi");

                    b.HasIndex("MaKhoa");

                    b.ToTable("BACSI");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Benhnhan", b =>
                {
                    b.Property<int>("MaBenhNhan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("HoTen")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("LoaiTaiKhoan")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime");

                    b.Property<string>("SoDienThoai")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength(true);

                    b.Property<string>("TenNguoiThan")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TenTaiKhoan")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("MaBenhNhan");

                    b.ToTable("BENHNHAN");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Chitietdonthuoc", b =>
                {
                    b.Property<int>("MaDonThuoc")
                        .HasColumnType("int");

                    b.Property<int>("MaThuoc")
                        .HasColumnType("int");

                    b.Property<string>("HuongDanSuDung")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaDonThuoc", "MaThuoc");

                    b.HasIndex("MaThuoc");

                    b.ToTable("CHITIETDONTHUOC");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Chitiethoadonthuoc", b =>
                {
                    b.Property<int>("MaHoaDonThuoc")
                        .HasColumnType("int");

                    b.Property<int>("MaThuoc")
                        .HasColumnType("int");

                    b.Property<decimal?>("Gia")
                        .HasColumnType("decimal(18,0)");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal?>("ThanhTien")
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("MaHoaDonThuoc", "MaThuoc");

                    b.HasIndex("MaThuoc");

                    b.ToTable("CHITIETHOADONTHUOC");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Chitietphieunhap", b =>
                {
                    b.Property<int>("MaPhieuNhap")
                        .HasColumnType("int");

                    b.Property<int>("MaThuoc")
                        .HasColumnType("int");

                    b.Property<decimal?>("GiaThuoc")
                        .HasColumnType("decimal(18,0)");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal?>("ThanhTien")
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("MaPhieuNhap", "MaThuoc");

                    b.HasIndex("MaThuoc");

                    b.ToTable("CHITIETPHIEUNHAP");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Chitietphieuxetnghiem", b =>
                {
                    b.Property<int>("MaXetNghiem")
                        .HasColumnType("int");

                    b.Property<int>("MaPhieuXetNghiem")
                        .HasColumnType("int");

                    b.Property<decimal?>("ChiPhi")
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("MaXetNghiem", "MaPhieuXetNghiem");

                    b.HasIndex("MaPhieuXetNghiem");

                    b.ToTable("CHITIETPHIEUXETNGHIEM");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Dichvukham", b =>
                {
                    b.Property<int>("MaDichVu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("ChiPhi")
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("TenDichVu")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaDichVu");

                    b.ToTable("DICHVUKHAM");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Dichvuxetnghiem", b =>
                {
                    b.Property<int>("MaXetNghiem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("ChiPhi")
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("TenXetNghiem")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("MaXetNghiem");

                    b.ToTable("DICHVUXETNGHIEM");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Donthuoc", b =>
                {
                    b.Property<int>("MaDonThuoc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaHoSo")
                        .HasColumnType("int");

                    b.Property<string>("TenDonThuoc")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("MaDonThuoc");

                    b.HasIndex("MaHoSo");

                    b.ToTable("DONTHUOC");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Hoadonthuoc", b =>
                {
                    b.Property<int>("MaHoaDon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaBenhNhan")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayThanhToan")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("TongTien")
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("MaHoaDon");

                    b.HasIndex("MaBenhNhan");

                    b.ToTable("HOADONTHUOC");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Hosokham", b =>
                {
                    b.Property<int>("MaHoSo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChuanDoan")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("MaBacSi")
                        .HasColumnType("int");

                    b.Property<int?>("MaBenhNhan")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrieuChung")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("MaHoSo");

                    b.HasIndex("MaBacSi");

                    b.HasIndex("MaBenhNhan");

                    b.ToTable("HOSOKHAM");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Khoa", b =>
                {
                    b.Property<int>("MaKhoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenKhoa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaKhoa");

                    b.ToTable("KHOA");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Lichsudangnhap", b =>
                {
                    b.Property<int>("MaLichSu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaBenhNhan")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ThoiGianRa")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ThoiGianVao")
                        .HasColumnType("datetime");

                    b.HasKey("MaLichSu")
                        .HasName("PK_Table_1_1");

                    b.HasIndex("MaBenhNhan");

                    b.ToTable("LICHSUDANGNHAP");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Nhasanxuat", b =>
                {
                    b.Property<int>("MaNhaSanXuat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SoDienThoai")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength(true);

                    b.Property<string>("TenNhaSanXuat")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaNhaSanXuat")
                        .HasName("PK_Table_1");

                    b.ToTable("NHASANXUAT");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Phieudangkykham", b =>
                {
                    b.Property<int>("MaPhieuDangKy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaBenhNhan")
                        .HasColumnType("int");

                    b.Property<int?>("MaDichVu")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayDangKy")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("TongTien")
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("MaPhieuDangKy");

                    b.HasIndex("MaBenhNhan");

                    b.HasIndex("MaDichVu");

                    b.ToTable("PHIEUDANGKYKHAM");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Phieunhap", b =>
                {
                    b.Property<int>("MaPhieuNhap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaNhaSanXuat")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayNhap")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("TongTien")
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("MaPhieuNhap");

                    b.HasIndex("MaNhaSanXuat");

                    b.ToTable("PHIEUNHAP");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Phieuxetnghiem", b =>
                {
                    b.Property<int>("MaPhieuXetNghiem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaHoSo")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayThanhToan")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("TongTien")
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("MaPhieuXetNghiem");

                    b.HasIndex("MaHoSo");

                    b.ToTable("PHIEUXETNGHIEM");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Thuoc", b =>
                {
                    b.Property<int>("MaThuoc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Gia")
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("HuongDan")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("MaNguoiSua")
                        .HasColumnType("int");

                    b.Property<int?>("MaNhaSanXuat")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuongTonKho")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("ThoiDiemSua")
                        .HasColumnType("datetime");

                    b.HasKey("MaThuoc");

                    b.HasIndex("MaNhaSanXuat");

                    b.ToTable("THUOC");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Bacsi", b =>
                {
                    b.HasOne("WebPhongKhamNhi.Models.Khoa", "MaKhoaNavigation")
                        .WithMany("Bacsis")
                        .HasForeignKey("MaKhoa")
                        .HasConstraintName("FK_BACSI_KHOA");

                    b.Navigation("MaKhoaNavigation");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Chitietdonthuoc", b =>
                {
                    b.HasOne("WebPhongKhamNhi.Models.Donthuoc", "MaDonThuocNavigation")
                        .WithMany("Chitietdonthuocs")
                        .HasForeignKey("MaDonThuoc")
                        .HasConstraintName("FK_CHITIETDONTHUOC_DONTHUOC")
                        .IsRequired();

                    b.HasOne("WebPhongKhamNhi.Models.Thuoc", "MaThuocNavigation")
                        .WithMany("Chitietdonthuocs")
                        .HasForeignKey("MaThuoc")
                        .HasConstraintName("FK_CHITIETDONTHUOC_THUOC")
                        .IsRequired();

                    b.Navigation("MaDonThuocNavigation");

                    b.Navigation("MaThuocNavigation");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Chitiethoadonthuoc", b =>
                {
                    b.HasOne("WebPhongKhamNhi.Models.Hoadonthuoc", "MaHoaDonThuocNavigation")
                        .WithMany("Chitiethoadonthuocs")
                        .HasForeignKey("MaHoaDonThuoc")
                        .HasConstraintName("FK_CHITIETHOADONTHUOC_HOADONTHUOC")
                        .IsRequired();

                    b.HasOne("WebPhongKhamNhi.Models.Thuoc", "MaThuocNavigation")
                        .WithMany("Chitiethoadonthuocs")
                        .HasForeignKey("MaThuoc")
                        .HasConstraintName("FK_CHITIETHOADONTHUOC_THUOC")
                        .IsRequired();

                    b.Navigation("MaHoaDonThuocNavigation");

                    b.Navigation("MaThuocNavigation");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Chitietphieunhap", b =>
                {
                    b.HasOne("WebPhongKhamNhi.Models.Phieunhap", "MaPhieuNhapNavigation")
                        .WithMany("Chitietphieunhaps")
                        .HasForeignKey("MaPhieuNhap")
                        .HasConstraintName("FK_CHITIETPHIEUNHAP_PHIEUNHAP")
                        .IsRequired();

                    b.HasOne("WebPhongKhamNhi.Models.Thuoc", "MaThuocNavigation")
                        .WithMany("Chitietphieunhaps")
                        .HasForeignKey("MaThuoc")
                        .HasConstraintName("FK_CHITIETPHIEUNHAP_THUOC")
                        .IsRequired();

                    b.Navigation("MaPhieuNhapNavigation");

                    b.Navigation("MaThuocNavigation");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Chitietphieuxetnghiem", b =>
                {
                    b.HasOne("WebPhongKhamNhi.Models.Phieuxetnghiem", "MaPhieuXetNghiemNavigation")
                        .WithMany("Chitietphieuxetnghiems")
                        .HasForeignKey("MaPhieuXetNghiem")
                        .HasConstraintName("FK_CHITIETPHIEUXETNGHIEM_PHIEUXETNGHIEM")
                        .IsRequired();

                    b.HasOne("WebPhongKhamNhi.Models.Dichvuxetnghiem", "MaXetNghiemNavigation")
                        .WithMany("Chitietphieuxetnghiems")
                        .HasForeignKey("MaXetNghiem")
                        .HasConstraintName("FK_CHITIETPHIEUXETNGHIEM_DICHVUXETNGHIEM")
                        .IsRequired();

                    b.Navigation("MaPhieuXetNghiemNavigation");

                    b.Navigation("MaXetNghiemNavigation");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Donthuoc", b =>
                {
                    b.HasOne("WebPhongKhamNhi.Models.Hosokham", "MaHoSoNavigation")
                        .WithMany("Donthuocs")
                        .HasForeignKey("MaHoSo")
                        .HasConstraintName("FK_DONTHUOC_HOSOKHAM");

                    b.Navigation("MaHoSoNavigation");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Hoadonthuoc", b =>
                {
                    b.HasOne("WebPhongKhamNhi.Models.Benhnhan", "MaBenhNhanNavigation")
                        .WithMany("Hoadonthuocs")
                        .HasForeignKey("MaBenhNhan")
                        .HasConstraintName("FK_HOADONTHUOC_BENHNHAN");

                    b.Navigation("MaBenhNhanNavigation");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Hosokham", b =>
                {
                    b.HasOne("WebPhongKhamNhi.Models.Bacsi", "MaBacSiNavigation")
                        .WithMany("Hosokhams")
                        .HasForeignKey("MaBacSi")
                        .HasConstraintName("FK_HOSOKHAM_BACSI");

                    b.HasOne("WebPhongKhamNhi.Models.Benhnhan", "MaBenhNhanNavigation")
                        .WithMany("Hosokhams")
                        .HasForeignKey("MaBenhNhan")
                        .HasConstraintName("FK_HOSOKHAM_BENHNHAN");

                    b.Navigation("MaBacSiNavigation");

                    b.Navigation("MaBenhNhanNavigation");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Lichsudangnhap", b =>
                {
                    b.HasOne("WebPhongKhamNhi.Models.Benhnhan", "MaBenhNhanNavigation")
                        .WithMany("Lichsudangnhaps")
                        .HasForeignKey("MaBenhNhan")
                        .HasConstraintName("FK_LICHSUKHAM_BENHNHAN");

                    b.Navigation("MaBenhNhanNavigation");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Phieudangkykham", b =>
                {
                    b.HasOne("WebPhongKhamNhi.Models.Benhnhan", "MaBenhNhanNavigation")
                        .WithMany("Phieudangkykhams")
                        .HasForeignKey("MaBenhNhan")
                        .HasConstraintName("FK_PHIEUDANGKYKHAM_BENHNHAN");

                    b.HasOne("WebPhongKhamNhi.Models.Dichvukham", "MaDichVuNavigation")
                        .WithMany("Phieudangkykhams")
                        .HasForeignKey("MaDichVu")
                        .HasConstraintName("FK_PHIEUDANGKYKHAM_DICHVUKHAM");

                    b.Navigation("MaBenhNhanNavigation");

                    b.Navigation("MaDichVuNavigation");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Phieunhap", b =>
                {
                    b.HasOne("WebPhongKhamNhi.Models.Nhasanxuat", "MaNhaSanXuatNavigation")
                        .WithMany("Phieunhaps")
                        .HasForeignKey("MaNhaSanXuat")
                        .HasConstraintName("FK_PHIEUNHAP_NHASANXUAT");

                    b.Navigation("MaNhaSanXuatNavigation");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Phieuxetnghiem", b =>
                {
                    b.HasOne("WebPhongKhamNhi.Models.Hosokham", "MaHoSoNavigation")
                        .WithMany("Phieuxetnghiems")
                        .HasForeignKey("MaHoSo")
                        .HasConstraintName("FK_PHIEUXETNGHIEM_HOSOKHAM");

                    b.Navigation("MaHoSoNavigation");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Thuoc", b =>
                {
                    b.HasOne("WebPhongKhamNhi.Models.Nhasanxuat", "MaNhaSanXuatNavigation")
                        .WithMany("Thuocs")
                        .HasForeignKey("MaNhaSanXuat")
                        .HasConstraintName("FK_THUOC_NHASANXUAT");

                    b.Navigation("MaNhaSanXuatNavigation");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Bacsi", b =>
                {
                    b.Navigation("Hosokhams");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Benhnhan", b =>
                {
                    b.Navigation("Hoadonthuocs");

                    b.Navigation("Hosokhams");

                    b.Navigation("Lichsudangnhaps");

                    b.Navigation("Phieudangkykhams");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Dichvukham", b =>
                {
                    b.Navigation("Phieudangkykhams");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Dichvuxetnghiem", b =>
                {
                    b.Navigation("Chitietphieuxetnghiems");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Donthuoc", b =>
                {
                    b.Navigation("Chitietdonthuocs");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Hoadonthuoc", b =>
                {
                    b.Navigation("Chitiethoadonthuocs");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Hosokham", b =>
                {
                    b.Navigation("Donthuocs");

                    b.Navigation("Phieuxetnghiems");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Khoa", b =>
                {
                    b.Navigation("Bacsis");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Nhasanxuat", b =>
                {
                    b.Navigation("Phieunhaps");

                    b.Navigation("Thuocs");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Phieunhap", b =>
                {
                    b.Navigation("Chitietphieunhaps");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Phieuxetnghiem", b =>
                {
                    b.Navigation("Chitietphieuxetnghiems");
                });

            modelBuilder.Entity("WebPhongKhamNhi.Models.Thuoc", b =>
                {
                    b.Navigation("Chitietdonthuocs");

                    b.Navigation("Chitiethoadonthuocs");

                    b.Navigation("Chitietphieunhaps");
                });
#pragma warning restore 612, 618
        }
    }
}

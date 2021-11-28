using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPhongKhamNhi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BENHNHAN",
                columns: table => new
                {
                    MaBenhNhan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TenTaiKhoan = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    MatKhau = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TenNguoiThan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoDienThoai = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    LoaiTaiKhoan = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BENHNHAN", x => x.MaBenhNhan);
                });

            migrationBuilder.CreateTable(
                name: "DICHVUKHAM",
                columns: table => new
                {
                    MaDichVu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDichVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChiPhi = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DICHVUKHAM", x => x.MaDichVu);
                });

            migrationBuilder.CreateTable(
                name: "DICHVUXETNGHIEM",
                columns: table => new
                {
                    MaXetNghiem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenXetNghiem = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ChiPhi = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DICHVUXETNGHIEM", x => x.MaXetNghiem);
                });

            migrationBuilder.CreateTable(
                name: "KHOA",
                columns: table => new
                {
                    MaKhoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHOA", x => x.MaKhoa);
                });

            migrationBuilder.CreateTable(
                name: "NHASANXUAT",
                columns: table => new
                {
                    MaNhaSanXuat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhaSanXuat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SoDienThoai = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1", x => x.MaNhaSanXuat);
                });

            migrationBuilder.CreateTable(
                name: "HOADONTHUOC",
                columns: table => new
                {
                    MaHoaDon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaBenhNhan = table.Column<int>(type: "int", nullable: true),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime", nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOADONTHUOC", x => x.MaHoaDon);
                    table.ForeignKey(
                        name: "FK_HOADONTHUOC_BENHNHAN",
                        column: x => x.MaBenhNhan,
                        principalTable: "BENHNHAN",
                        principalColumn: "MaBenhNhan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LICHSUDANGNHAP",
                columns: table => new
                {
                    MaLichSu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGianVao = table.Column<DateTime>(type: "datetime", nullable: true),
                    ThoiGianRa = table.Column<DateTime>(type: "datetime", nullable: true),
                    MaBenhNhan = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_1", x => x.MaLichSu);
                    table.ForeignKey(
                        name: "FK_LICHSUKHAM_BENHNHAN",
                        column: x => x.MaBenhNhan,
                        principalTable: "BENHNHAN",
                        principalColumn: "MaBenhNhan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PHIEUDANGKYKHAM",
                columns: table => new
                {
                    MaPhieuDangKy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayDangKy = table.Column<DateTime>(type: "datetime", nullable: true),
                    MaBenhNhan = table.Column<int>(type: "int", nullable: true),
                    MaDichVu = table.Column<int>(type: "int", nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHIEUDANGKYKHAM", x => x.MaPhieuDangKy);
                    table.ForeignKey(
                        name: "FK_PHIEUDANGKYKHAM_BENHNHAN",
                        column: x => x.MaBenhNhan,
                        principalTable: "BENHNHAN",
                        principalColumn: "MaBenhNhan",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PHIEUDANGKYKHAM_DICHVUKHAM",
                        column: x => x.MaDichVu,
                        principalTable: "DICHVUKHAM",
                        principalColumn: "MaDichVu",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BACSI",
                columns: table => new
                {
                    MaBacSi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrinhDo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoDienThoai = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    MaKhoa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BACSI", x => x.MaBacSi);
                    table.ForeignKey(
                        name: "FK_BACSI_KHOA",
                        column: x => x.MaKhoa,
                        principalTable: "KHOA",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PHIEUNHAP",
                columns: table => new
                {
                    MaPhieuNhap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayNhap = table.Column<DateTime>(type: "datetime", nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    MaNhaSanXuat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHIEUNHAP", x => x.MaPhieuNhap);
                    table.ForeignKey(
                        name: "FK_PHIEUNHAP_NHASANXUAT",
                        column: x => x.MaNhaSanXuat,
                        principalTable: "NHASANXUAT",
                        principalColumn: "MaNhaSanXuat",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "THUOC",
                columns: table => new
                {
                    MaThuoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhaSanXuat = table.Column<int>(type: "int", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HuongDan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SoLuongTonKho = table.Column<int>(type: "int", nullable: true),
                    Gia = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    ThoiDiemSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    MaNguoiSua = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THUOC", x => x.MaThuoc);
                    table.ForeignKey(
                        name: "FK_THUOC_NHASANXUAT",
                        column: x => x.MaNhaSanXuat,
                        principalTable: "NHASANXUAT",
                        principalColumn: "MaNhaSanXuat",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HOSOKHAM",
                columns: table => new
                {
                    MaHoSo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrieuChung = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ChuanDoan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaBacSi = table.Column<int>(type: "int", nullable: true),
                    MaBenhNhan = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOSOKHAM", x => x.MaHoSo);
                    table.ForeignKey(
                        name: "FK_HOSOKHAM_BACSI",
                        column: x => x.MaBacSi,
                        principalTable: "BACSI",
                        principalColumn: "MaBacSi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HOSOKHAM_BENHNHAN",
                        column: x => x.MaBenhNhan,
                        principalTable: "BENHNHAN",
                        principalColumn: "MaBenhNhan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETHOADONTHUOC",
                columns: table => new
                {
                    MaHoaDonThuoc = table.Column<int>(type: "int", nullable: false),
                    MaThuoc = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    Gia = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHITIETHOADONTHUOC", x => new { x.MaHoaDonThuoc, x.MaThuoc });
                    table.ForeignKey(
                        name: "FK_CHITIETHOADONTHUOC_HOADONTHUOC",
                        column: x => x.MaHoaDonThuoc,
                        principalTable: "HOADONTHUOC",
                        principalColumn: "MaHoaDon",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CHITIETHOADONTHUOC_THUOC",
                        column: x => x.MaThuoc,
                        principalTable: "THUOC",
                        principalColumn: "MaThuoc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETPHIEUNHAP",
                columns: table => new
                {
                    MaPhieuNhap = table.Column<int>(type: "int", nullable: false),
                    MaThuoc = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    GiaThuoc = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHITIETPHIEUNHAP", x => new { x.MaPhieuNhap, x.MaThuoc });
                    table.ForeignKey(
                        name: "FK_CHITIETPHIEUNHAP_PHIEUNHAP",
                        column: x => x.MaPhieuNhap,
                        principalTable: "PHIEUNHAP",
                        principalColumn: "MaPhieuNhap",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CHITIETPHIEUNHAP_THUOC",
                        column: x => x.MaThuoc,
                        principalTable: "THUOC",
                        principalColumn: "MaThuoc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DONTHUOC",
                columns: table => new
                {
                    MaDonThuoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHoSo = table.Column<int>(type: "int", nullable: true),
                    TenDonThuoc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DONTHUOC", x => x.MaDonThuoc);
                    table.ForeignKey(
                        name: "FK_DONTHUOC_HOSOKHAM",
                        column: x => x.MaHoSo,
                        principalTable: "HOSOKHAM",
                        principalColumn: "MaHoSo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PHIEUXETNGHIEM",
                columns: table => new
                {
                    MaPhieuXetNghiem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime", nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    MaHoSo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHIEUXETNGHIEM", x => x.MaPhieuXetNghiem);
                    table.ForeignKey(
                        name: "FK_PHIEUXETNGHIEM_HOSOKHAM",
                        column: x => x.MaHoSo,
                        principalTable: "HOSOKHAM",
                        principalColumn: "MaHoSo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETDONTHUOC",
                columns: table => new
                {
                    MaDonThuoc = table.Column<int>(type: "int", nullable: false),
                    MaThuoc = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    HuongDanSuDung = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHITIETDONTHUOC", x => new { x.MaDonThuoc, x.MaThuoc });
                    table.ForeignKey(
                        name: "FK_CHITIETDONTHUOC_DONTHUOC",
                        column: x => x.MaDonThuoc,
                        principalTable: "DONTHUOC",
                        principalColumn: "MaDonThuoc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CHITIETDONTHUOC_THUOC",
                        column: x => x.MaThuoc,
                        principalTable: "THUOC",
                        principalColumn: "MaThuoc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETPHIEUXETNGHIEM",
                columns: table => new
                {
                    MaXetNghiem = table.Column<int>(type: "int", nullable: false),
                    MaPhieuXetNghiem = table.Column<int>(type: "int", nullable: false),
                    ChiPhi = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHITIETPHIEUXETNGHIEM", x => new { x.MaXetNghiem, x.MaPhieuXetNghiem });
                    table.ForeignKey(
                        name: "FK_CHITIETPHIEUXETNGHIEM_DICHVUXETNGHIEM",
                        column: x => x.MaXetNghiem,
                        principalTable: "DICHVUXETNGHIEM",
                        principalColumn: "MaXetNghiem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CHITIETPHIEUXETNGHIEM_PHIEUXETNGHIEM",
                        column: x => x.MaPhieuXetNghiem,
                        principalTable: "PHIEUXETNGHIEM",
                        principalColumn: "MaPhieuXetNghiem",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BACSI_MaKhoa",
                table: "BACSI",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETDONTHUOC_MaThuoc",
                table: "CHITIETDONTHUOC",
                column: "MaThuoc");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETHOADONTHUOC_MaThuoc",
                table: "CHITIETHOADONTHUOC",
                column: "MaThuoc");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETPHIEUNHAP_MaThuoc",
                table: "CHITIETPHIEUNHAP",
                column: "MaThuoc");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETPHIEUXETNGHIEM_MaPhieuXetNghiem",
                table: "CHITIETPHIEUXETNGHIEM",
                column: "MaPhieuXetNghiem");

            migrationBuilder.CreateIndex(
                name: "IX_DONTHUOC_MaHoSo",
                table: "DONTHUOC",
                column: "MaHoSo");

            migrationBuilder.CreateIndex(
                name: "IX_HOADONTHUOC_MaBenhNhan",
                table: "HOADONTHUOC",
                column: "MaBenhNhan");

            migrationBuilder.CreateIndex(
                name: "IX_HOSOKHAM_MaBacSi",
                table: "HOSOKHAM",
                column: "MaBacSi");

            migrationBuilder.CreateIndex(
                name: "IX_HOSOKHAM_MaBenhNhan",
                table: "HOSOKHAM",
                column: "MaBenhNhan");

            migrationBuilder.CreateIndex(
                name: "IX_LICHSUDANGNHAP_MaBenhNhan",
                table: "LICHSUDANGNHAP",
                column: "MaBenhNhan");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUDANGKYKHAM_MaBenhNhan",
                table: "PHIEUDANGKYKHAM",
                column: "MaBenhNhan");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUDANGKYKHAM_MaDichVu",
                table: "PHIEUDANGKYKHAM",
                column: "MaDichVu");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUNHAP_MaNhaSanXuat",
                table: "PHIEUNHAP",
                column: "MaNhaSanXuat");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUXETNGHIEM_MaHoSo",
                table: "PHIEUXETNGHIEM",
                column: "MaHoSo");

            migrationBuilder.CreateIndex(
                name: "IX_THUOC_MaNhaSanXuat",
                table: "THUOC",
                column: "MaNhaSanXuat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHITIETDONTHUOC");

            migrationBuilder.DropTable(
                name: "CHITIETHOADONTHUOC");

            migrationBuilder.DropTable(
                name: "CHITIETPHIEUNHAP");

            migrationBuilder.DropTable(
                name: "CHITIETPHIEUXETNGHIEM");

            migrationBuilder.DropTable(
                name: "LICHSUDANGNHAP");

            migrationBuilder.DropTable(
                name: "PHIEUDANGKYKHAM");

            migrationBuilder.DropTable(
                name: "DONTHUOC");

            migrationBuilder.DropTable(
                name: "HOADONTHUOC");

            migrationBuilder.DropTable(
                name: "PHIEUNHAP");

            migrationBuilder.DropTable(
                name: "THUOC");

            migrationBuilder.DropTable(
                name: "DICHVUXETNGHIEM");

            migrationBuilder.DropTable(
                name: "PHIEUXETNGHIEM");

            migrationBuilder.DropTable(
                name: "DICHVUKHAM");

            migrationBuilder.DropTable(
                name: "NHASANXUAT");

            migrationBuilder.DropTable(
                name: "HOSOKHAM");

            migrationBuilder.DropTable(
                name: "BACSI");

            migrationBuilder.DropTable(
                name: "BENHNHAN");

            migrationBuilder.DropTable(
                name: "KHOA");
        }
    }
}

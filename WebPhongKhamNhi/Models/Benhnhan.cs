using System;
using System.Collections.Generic;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Benhnhan
    {
        public Benhnhan()
        {
            Hoadonthuocs = new HashSet<Hoadonthuoc>();
            Hosokhams = new HashSet<Hosokham>();
            Lichsudangnhaps = new HashSet<Lichsudangnhap>();
            Phieudangkykhams = new HashSet<Phieudangkykham>();
        }

        public int MaBenhNhan { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string TenNguoiThan { get; set; }
        public string SoDienThoai { get; set; }
        public int? LoaiTaiKhoan { get; set; }

        public virtual ICollection<Hoadonthuoc> Hoadonthuocs { get; set; }
        public virtual ICollection<Hosokham> Hosokhams { get; set; }
        public virtual ICollection<Lichsudangnhap> Lichsudangnhaps { get; set; }
        public virtual ICollection<Phieudangkykham> Phieudangkykhams { get; set; }
    }
}

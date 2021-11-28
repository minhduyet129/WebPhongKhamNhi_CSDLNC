using System;
using System.Collections.Generic;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Chitietphieunhap
    {
        public int MaPhieuNhap { get; set; }
        public int MaThuoc { get; set; }
        public int? SoLuong { get; set; }
        public decimal? GiaThuoc { get; set; }
        public decimal? ThanhTien { get; set; }

        public virtual Phieunhap MaPhieuNhapNavigation { get; set; }
        public virtual Thuoc MaThuocNavigation { get; set; }
    }
}

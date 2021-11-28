using System;
using System.Collections.Generic;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Chitiethoadonthuoc
    {
        public int MaHoaDonThuoc { get; set; }
        public int MaThuoc { get; set; }
        public int? SoLuong { get; set; }
        public decimal? Gia { get; set; }
        public decimal? ThanhTien { get; set; }

        public virtual Hoadonthuoc MaHoaDonThuocNavigation { get; set; }
        public virtual Thuoc MaThuocNavigation { get; set; }
    }
}

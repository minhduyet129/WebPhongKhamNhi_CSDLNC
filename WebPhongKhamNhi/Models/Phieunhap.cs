using System;
using System.Collections.Generic;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Phieunhap
    {
        public Phieunhap()
        {
            Chitietphieunhaps = new HashSet<Chitietphieunhap>();
        }

        public int MaPhieuNhap { get; set; }
        public DateTime? NgayNhap { get; set; }
        public decimal? TongTien { get; set; }
        public int? MaNhaSanXuat { get; set; }

        public virtual Nhasanxuat MaNhaSanXuatNavigation { get; set; }
        public virtual ICollection<Chitietphieunhap> Chitietphieunhaps { get; set; }
    }
}

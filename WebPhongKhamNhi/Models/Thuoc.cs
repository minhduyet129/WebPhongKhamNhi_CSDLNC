using System;
using System.Collections.Generic;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Thuoc
    {
        public Thuoc()
        {
            Chitietdonthuocs = new HashSet<Chitietdonthuoc>();
            Chitiethoadonthuocs = new HashSet<Chitiethoadonthuoc>();
            Chitietphieunhaps = new HashSet<Chitietphieunhap>();
        }

        public int MaThuoc { get; set; }
        public int? MaNhaSanXuat { get; set; }
        public string Ten { get; set; }
        public string HuongDan { get; set; }
        public int? SoLuongTonKho { get; set; }
        public decimal? Gia { get; set; }
        public DateTime? ThoiDiemSua { get; set; }
        public int? MaNguoiSua { get; set; }

        public virtual Nhasanxuat MaNhaSanXuatNavigation { get; set; }
        public virtual ICollection<Chitietdonthuoc> Chitietdonthuocs { get; set; }
        public virtual ICollection<Chitiethoadonthuoc> Chitiethoadonthuocs { get; set; }
        public virtual ICollection<Chitietphieunhap> Chitietphieunhaps { get; set; }
    }
}

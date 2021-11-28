using System;
using System.Collections.Generic;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Nhasanxuat
    {
        public Nhasanxuat()
        {
            Phieunhaps = new HashSet<Phieunhap>();
            Thuocs = new HashSet<Thuoc>();
        }

        public int MaNhaSanXuat { get; set; }
        public string TenNhaSanXuat { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public virtual ICollection<Phieunhap> Phieunhaps { get; set; }
        public virtual ICollection<Thuoc> Thuocs { get; set; }
    }
}

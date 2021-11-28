using System;
using System.Collections.Generic;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Hoadonthuoc
    {
        public Hoadonthuoc()
        {
            Chitiethoadonthuocs = new HashSet<Chitiethoadonthuoc>();
        }

        public int MaHoaDon { get; set; }
        public int? MaBenhNhan { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public decimal? TongTien { get; set; }

        public virtual Benhnhan MaBenhNhanNavigation { get; set; }
        public virtual ICollection<Chitiethoadonthuoc> Chitiethoadonthuocs { get; set; }
    }
}

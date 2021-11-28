using System;
using System.Collections.Generic;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Phieuxetnghiem
    {
        public Phieuxetnghiem()
        {
            Chitietphieuxetnghiems = new HashSet<Chitietphieuxetnghiem>();
        }

        public int MaPhieuXetNghiem { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public decimal? TongTien { get; set; }
        public int? MaHoSo { get; set; }

        public virtual Hosokham MaHoSoNavigation { get; set; }
        public virtual ICollection<Chitietphieuxetnghiem> Chitietphieuxetnghiems { get; set; }
    }
}

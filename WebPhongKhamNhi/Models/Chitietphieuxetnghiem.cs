using System;
using System.Collections.Generic;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Chitietphieuxetnghiem
    {
        public int MaXetNghiem { get; set; }
        public int MaPhieuXetNghiem { get; set; }
        public decimal? ChiPhi { get; set; }

        public virtual Phieuxetnghiem MaPhieuXetNghiemNavigation { get; set; }
        public virtual Dichvuxetnghiem MaXetNghiemNavigation { get; set; }
       
    }
}

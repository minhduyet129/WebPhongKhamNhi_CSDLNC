using System;
using System.Collections.Generic;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Donthuoc
    {
        public Donthuoc()
        {
            Chitietdonthuocs = new HashSet<Chitietdonthuoc>();
        }

        public int MaDonThuoc { get; set; }
        public int? MaHoSo { get; set; }
        public string TenDonThuoc { get; set; }

        public virtual Hosokham MaHoSoNavigation { get; set; }
        public virtual ICollection<Chitietdonthuoc> Chitietdonthuocs { get; set; }
    }
}

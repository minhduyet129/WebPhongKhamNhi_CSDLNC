using System;
using System.Collections.Generic;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Lichsudangnhap
    {
        public int MaLichSu { get; set; }
        public DateTime? ThoiGianVao { get; set; }
        public DateTime? ThoiGianRa { get; set; }
        public int? MaBenhNhan { get; set; }

        public virtual Benhnhan MaBenhNhanNavigation { get; set; }
    }
}

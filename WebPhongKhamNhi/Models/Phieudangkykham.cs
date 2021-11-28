using System;
using System.Collections.Generic;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Phieudangkykham
    {
        public int MaPhieuDangKy { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public int? MaBenhNhan { get; set; }
        public int? MaDichVu { get; set; }
        public decimal? TongTien { get; set; }

        public virtual Benhnhan MaBenhNhanNavigation { get; set; }
        public virtual Dichvukham MaDichVuNavigation { get; set; }
    }
}

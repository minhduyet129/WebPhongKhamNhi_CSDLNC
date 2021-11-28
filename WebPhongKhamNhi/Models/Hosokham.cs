using System;
using System.Collections.Generic;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Hosokham
    {
        public Hosokham()
        {
            Donthuocs = new HashSet<Donthuoc>();
            Phieuxetnghiems = new HashSet<Phieuxetnghiem>();
        }

        public int MaHoSo { get; set; }
        public string TrieuChung { get; set; }
        public string ChuanDoan { get; set; }
        public int? MaBacSi { get; set; }
        public int? MaBenhNhan { get; set; }

        public virtual Bacsi MaBacSiNavigation { get; set; }
        public virtual Benhnhan MaBenhNhanNavigation { get; set; }
        public virtual ICollection<Donthuoc> Donthuocs { get; set; }
        public virtual ICollection<Phieuxetnghiem> Phieuxetnghiems { get; set; }
    }
}

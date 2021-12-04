using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name ="Triệu chứng")]
        public string TrieuChung { get; set; }
        [Display(Name ="Chuẩn đoán")]
        public string ChuanDoan { get; set; }
        [Display(Name ="Ngày tạo")]
        public DateTime NgayTao { get; set; }
        public int? MaBacSi { get; set; }
        public int? MaBenhNhan { get; set; }

        public virtual Bacsi MaBacSiNavigation { get; set; }
        public virtual Benhnhan MaBenhNhanNavigation { get; set; }
        public virtual ICollection<Donthuoc> Donthuocs { get; set; }
        public virtual ICollection<Phieuxetnghiem> Phieuxetnghiems { get; set; }
    }
}

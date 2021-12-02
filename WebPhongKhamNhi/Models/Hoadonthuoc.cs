using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Hoadonthuoc
    {
        public Hoadonthuoc()
        {
            Chitiethoadonthuocs = new HashSet<Chitiethoadonthuoc>();
        }
        [Display(Name ="Mã hóa đơn")]
        public int MaHoaDon { get; set; }
        public int? MaBenhNhan { get; set; }
        [Display(Name ="Ngày thanh toán")]
        public DateTime? NgayThanhToan { get; set; }
        [Display(Name ="Tổng tiền")]
        public decimal? TongTien { get; set; }

        public virtual Benhnhan MaBenhNhanNavigation { get; set; }
        public virtual ICollection<Chitiethoadonthuoc> Chitiethoadonthuocs { get; set; }
    }
}

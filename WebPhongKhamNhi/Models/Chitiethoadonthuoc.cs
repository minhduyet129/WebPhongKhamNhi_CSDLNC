using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Chitiethoadonthuoc
    {
        public int MaHoaDonThuoc { get; set; }
        public int MaThuoc { get; set; }
        [Display(Name ="Số lượng")]
        public int? SoLuong { get; set; }
        [Display(Name ="Giá")]
        public decimal? Gia { get; set; }
        [Display(Name ="Thành tiền")]
        public decimal? ThanhTien { get; set; }

        public virtual Hoadonthuoc MaHoaDonThuocNavigation { get; set; }
        public virtual Thuoc MaThuocNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Chitietdonthuoc
    {
        public int MaDonThuoc { get; set; }
        public int MaThuoc { get; set; }
        public int? SoLuong { get; set; }
        public string HuongDanSuDung { get; set; }

        public virtual Donthuoc MaDonThuocNavigation { get; set; }
        public virtual Thuoc MaThuocNavigation { get; set; }
    }
}

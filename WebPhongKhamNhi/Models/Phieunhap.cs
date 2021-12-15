using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Phieunhap
    {
        public Phieunhap()
        {
            Chitietphieunhaps = new HashSet<Chitietphieunhap>();
        }

        [DisplayName("Mã phiếu nhập")]
        public int MaPhieuNhap { get; set; }

        [DisplayName("Ngày nhập")]
        [Required(ErrorMessage ="{0} không được để trống")]
        public DateTime? NgayNhap { get; set; }

        [DisplayName("Tổng tiền")]
        public decimal? TongTien { get; set; }

        [DisplayName("Mã nhà sản xuất")]
        public int? MaNhaSanXuat { get; set; }

        public virtual Nhasanxuat MaNhaSanXuatNavigation { get; set; }
        public virtual ICollection<Chitietphieunhap> Chitietphieunhaps { get; set; }
    }
}

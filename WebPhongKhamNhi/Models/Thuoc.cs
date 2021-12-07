using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Thuoc
    {
        public Thuoc()
        {
            Chitietdonthuocs = new HashSet<Chitietdonthuoc>();
            Chitiethoadonthuocs = new HashSet<Chitiethoadonthuoc>();
            Chitietphieunhaps = new HashSet<Chitietphieunhap>();
        }

        public int MaThuoc { get; set; }
        public int? MaNhaSanXuat { get; set; }
        [Display(Name ="Tên thuốc")]
        [Required(ErrorMessage ="{0} không được bỏ trống!")]
        public string Ten { get; set; }
        [Display(Name ="Hướng dẫn sử dụng")]
        [Required(ErrorMessage = "{0} không được bỏ trống!")]
        public string HuongDan { get; set; }
        [Display(Name ="Số lượng tồn kho")]
        public int? SoLuongTonKho { get; set; }
        [Display(Name ="Giá")]
        [Required(ErrorMessage = "{0} không được bỏ trống!")]
        public decimal? Gia { get; set; }
        public DateTime? ThoiDiemSua { get; set; }
        public int? MaNguoiSua { get; set; }

        public virtual Nhasanxuat MaNhaSanXuatNavigation { get; set; }
        public virtual ICollection<Chitietdonthuoc> Chitietdonthuocs { get; set; }
        public virtual ICollection<Chitiethoadonthuoc> Chitiethoadonthuocs { get; set; }
        public virtual ICollection<Chitietphieunhap> Chitietphieunhaps { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Benhnhan
    {
        public Benhnhan()
        {
            Hoadonthuocs = new HashSet<Hoadonthuoc>();
            Hosokhams = new HashSet<Hosokham>();
            Lichsudangnhaps = new HashSet<Lichsudangnhap>();
            Phieudangkykhams = new HashSet<Phieudangkykham>();
        }

        public int MaBenhNhan { get; set; }
        [Display(Name ="Họ và tên")]
        [Required(ErrorMessage = "{0} không được bỏ trống.")]
        public string HoTen { get; set; }
        [Display(Name ="Ngày sinh")]
        [Required(ErrorMessage = "{0} không được bỏ trống.")]
        public DateTime? NgaySinh { get; set; }
        [Display(Name ="Địa chỉ")]
        [Required(ErrorMessage = "{0} không được bỏ trống.")]
        public string DiaChi { get; set; }
        [Display(Name ="Tên tài khoản")]
        public string TenTaiKhoan { get; set; }
        [Display(Name ="Mật khẩu")]
        public string MatKhau { get; set; }
        [Display(Name ="Tên người thân")]
        public string TenNguoiThan { get; set; }
        [Display(Name ="Số điện thoại")]
        [Required(ErrorMessage = "{0} không được bỏ trống.")]
        [StringLength(10, MinimumLength = 9, ErrorMessage = "{0} có từ {2} đến {1} số")]
        public string SoDienThoai { get; set; }
        [Display(Name ="Loại tài khoản")]
        [Required(ErrorMessage = "{0} không được bỏ trống.")]
        public int? LoaiTaiKhoan { get; set; }

        public virtual ICollection<Hoadonthuoc> Hoadonthuocs { get; set; }
        public virtual ICollection<Hosokham> Hosokhams { get; set; }
        public virtual ICollection<Lichsudangnhap> Lichsudangnhaps { get; set; }
        public virtual ICollection<Phieudangkykham> Phieudangkykhams { get; set; }
    }
}

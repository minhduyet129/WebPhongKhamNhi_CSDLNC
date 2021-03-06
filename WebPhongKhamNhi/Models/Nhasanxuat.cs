using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Nhasanxuat
    {
        public Nhasanxuat()
        {
            Phieunhaps = new HashSet<Phieunhap>();
            Thuocs = new HashSet<Thuoc>();
        }

        [Display(Name = "Mã nhà sản xuất")]
        public int MaNhaSanXuat { get; set; }

        [Display(Name ="Tên nhà sản xuất")]
        [Required(ErrorMessage ="{0} không được bỏ trống.")]
        public string TenNhaSanXuat { get; set; }

        [Display(Name ="Địa chỉ")]
        public string DiaChi { get; set; }

        [Display(Name ="Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "{0} không được bỏ trống.")]
        [RegularExpression(@"\d+", ErrorMessage = "Bạn đã nhập sai số điện thoại")]
        [StringLength(10, MinimumLength =9, ErrorMessage ="{0} có từ {2} đến {1} chữ số")]
        public string SoDienThoai { get; set; }

        public virtual ICollection<Phieunhap> Phieunhaps { get; set; }
        public virtual ICollection<Thuoc> Thuocs { get; set; }
    }
}

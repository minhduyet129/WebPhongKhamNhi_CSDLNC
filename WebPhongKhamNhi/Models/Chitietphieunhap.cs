using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    
    public partial class Chitietphieunhap
    {
        [DisplayName("Mã phiếu nhập")]
        [Required(ErrorMessage ="{0} không được trống")]
        public int MaPhieuNhap { get; set; }

        [DisplayName("Mã thuốc")]
        [Required(ErrorMessage = "{0} không được trống.")]
        public int MaThuoc { get; set; }

        [DisplayName("Số lượng")]
        [Range(1,int.MaxValue, ErrorMessage ="{0} không nhỏ hơn 1.")]
        public int? SoLuong { get; set; }

        [DisplayName("Giá thuốc")]
        [Range(0,int.MaxValue, ErrorMessage ="{0} không nhỏ hơn 0.")]
        public decimal? GiaThuoc { get; set; }

        [DisplayName("Thành tiền")]
        public decimal? ThanhTien { get; set; }

        public virtual Phieunhap MaPhieuNhapNavigation { get; set; }
        public virtual Thuoc MaThuocNavigation { get; set; }

        public Chitietphieunhap(int maThuoc, int? soLuong, decimal? giaThuoc)
        {
            MaThuoc = maThuoc;
            SoLuong = soLuong;
            GiaThuoc = giaThuoc;
            ThanhTien = giaThuoc*soLuong;
        }

        public Chitietphieunhap() { }
    }
}

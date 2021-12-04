using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Phieudangkykham
    {
        [DisplayName("Mã phiếu đăng ký")]
        public int MaPhieuDangKy { get; set; }

        [DisplayName("Ngày đăng ký")]
        [Required(ErrorMessage ="{0} không được để trống.")]
        public DateTime? NgayDangKy { get; set; }

        [DisplayName("Mã bệnh nhân")]
        public int? MaBenhNhan { get; set; }

        [DisplayName("Mã dịch vụ")]
        public int? MaDichVu { get; set; }

        [DisplayName("Tổng tiền")]
        public decimal? TongTien { get; set; }

        public virtual Benhnhan MaBenhNhanNavigation { get; set; }
        public virtual Dichvukham MaDichVuNavigation { get; set; }
    }
}

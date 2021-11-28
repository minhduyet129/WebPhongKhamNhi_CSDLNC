using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Bacsi
    {
        public Bacsi()
        {
            Hosokhams = new HashSet<Hosokham>();
        }

        public int MaBacSi { get; set; }
        [Display(Name="Họ và tên")]
        [Required(ErrorMessage ="{0} không được bỏ trống.")]
        public string HoTen { get; set; }
       
        [Display(Name = "Trình độ")]
        [Required(ErrorMessage = "{0} không được bỏ trống.")]
        public string TrinhDo { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "{0} không được bỏ trống.")]
        [StringLength(10,MinimumLength = 9,ErrorMessage ="{0} có từ {2} đến {1} số")]
        public string SoDienThoai { get; set; }
        public int? MaKhoa { get; set; }

        public virtual Khoa MaKhoaNavigation { get; set; }
        public virtual ICollection<Hosokham> Hosokhams { get; set; }
    }
}

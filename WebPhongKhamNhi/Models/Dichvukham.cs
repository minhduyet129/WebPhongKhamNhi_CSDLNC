using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Dichvukham
    {
        public Dichvukham()
        {
            Phieudangkykhams = new HashSet<Phieudangkykham>();
        }

        [DisplayName("Mã dịch vụ")]
        public int MaDichVu { get; set; }

        [DisplayName("Tên dịch vụ")]
        [Required(ErrorMessage ="{0} còn trống.")]
        public string TenDichVu { get; set; }

        [DisplayName("Chi phí")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} không nhỏ hơn 0.")]
        public decimal? ChiPhi { get; set; }

        public virtual ICollection<Phieudangkykham> Phieudangkykhams { get; set; }
    }
}

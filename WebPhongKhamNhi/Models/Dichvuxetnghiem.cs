using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Dichvuxetnghiem
    {
        public Dichvuxetnghiem()
        {
            Chitietphieuxetnghiems = new HashSet<Chitietphieuxetnghiem>();
        }

        public int MaXetNghiem { get; set; }
        [Display(Name = "Tên Dịch Vụ Xét Ngiệm")]
        [Required(ErrorMessage = "Tên Dịch Vụ Xét Ngiệm không được bỏ trống.")]
        public string TenXetNghiem { get; set; }
        public decimal? ChiPhi { get; set; }

        public virtual ICollection<Chitietphieuxetnghiem> Chitietphieuxetnghiems { get; set; }
    }
}

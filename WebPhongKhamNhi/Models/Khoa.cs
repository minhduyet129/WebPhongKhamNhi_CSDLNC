using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Khoa
    {
        public Khoa()
        {
            Bacsis = new HashSet<Bacsi>();
        }

        public int MaKhoa { get; set; }
        [Required(ErrorMessage = "{0} không được để trống ")]
        [Display(Name ="Tên khoa")]
        public string TenKhoa { get; set; }

        public virtual ICollection<Bacsi> Bacsis { get; set; }
    }
}

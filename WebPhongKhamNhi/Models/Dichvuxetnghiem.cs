using System;
using System.Collections.Generic;

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
        public string TenXetNghiem { get; set; }
        public decimal? ChiPhi { get; set; }

        public virtual ICollection<Chitietphieuxetnghiem> Chitietphieuxetnghiems { get; set; }
    }
}

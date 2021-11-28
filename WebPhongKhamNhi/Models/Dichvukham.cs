using System;
using System.Collections.Generic;

#nullable disable

namespace WebPhongKhamNhi.Models
{
    public partial class Dichvukham
    {
        public Dichvukham()
        {
            Phieudangkykhams = new HashSet<Phieudangkykham>();
        }

        public int MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public decimal? ChiPhi { get; set; }

        public virtual ICollection<Phieudangkykham> Phieudangkykhams { get; set; }
    }
}

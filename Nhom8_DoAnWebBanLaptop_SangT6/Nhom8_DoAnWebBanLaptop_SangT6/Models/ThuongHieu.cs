using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Nhom8_DoAnWebBanLaptop_SangT6.Models
{
    [Table("ThuongHieu")]
    public class ThuongHieu
    {
        public ThuongHieu()
        {
            this.SanPhams = new HashSet<SanPham>();
        }
        public int ID { get; set; }
        public string TenTH { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
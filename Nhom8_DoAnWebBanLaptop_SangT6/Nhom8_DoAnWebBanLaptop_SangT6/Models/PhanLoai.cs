using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Nhom8_DoAnWebBanLaptop_SangT6.Models
{
    [Table("PhanLoai")]
    public class PhanLoai
    {
        public PhanLoai()
        {
            this.SanPhams = new HashSet<SanPham>();
        }
        public int ID { get; set; }
        public string TenLoai { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
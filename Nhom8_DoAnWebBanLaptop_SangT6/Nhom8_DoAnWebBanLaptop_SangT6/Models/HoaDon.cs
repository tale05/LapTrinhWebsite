using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Nhom8_DoAnWebBanLaptop_SangT6.Models
{
    [Table("HoaDon")]
    public class HoaDon
    {
        public HoaDon()
        {
            this.ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }
        public int ID { get; set; }
        public double ThanhTien { get; set; }
        public int IDMaSP { get; set; }
        [ForeignKey("IDMaSP")]
        public virtual SanPham SanPhams { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
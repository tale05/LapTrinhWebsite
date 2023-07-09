using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Nhom8_DoAnWebBanLaptop_SangT6.Models
{
    [Table("ChiTietHoaDon")]
    public class ChiTietHoaDon
    {
        public int ID { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }

        public int MaKH { get; set; }
        [ForeignKey("MaKH")]
        public virtual KhachHang KhachHangs { get; set; }

        public int MaHD { get; set; }
        [ForeignKey("MaHD")]
        public virtual HoaDon HoaDons { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Nhom8_DoAnWebBanLaptop_SangT6.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        public KhachHang()
        {
            this.ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }
        public int ID { get; set; }
        public string TenKH { get; set; }
        public string NgaySinh { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
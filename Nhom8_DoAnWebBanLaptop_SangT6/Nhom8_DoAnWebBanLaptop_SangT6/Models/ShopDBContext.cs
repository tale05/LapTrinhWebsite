using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Nhom8_DoAnWebBanLaptop_SangT6.Models
{
    public class ShopDBContext : DbContext
    {
        public ShopDBContext() : base("Connection") { }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<ThuongHieu> ThuongHieus { get; set; }
        public DbSet<PhanLoai> PhanLoais { get;set;}
        public DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
    }
}
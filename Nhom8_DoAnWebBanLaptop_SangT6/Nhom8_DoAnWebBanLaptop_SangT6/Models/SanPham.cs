using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Nhom8_DoAnWebBanLaptop_SangT6.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        public SanPham()
        {
            this.ChiTietSanPhams = new HashSet<ChiTietSanPham>();
            //this.HoaDons = new HashSet<HoaDon>();
        }

        public int ID { get; set; }
        public string TenSanPham { get; set; }
        public double GiaBan { get; set; }
        public double GiaGiam { get; set; }
        public string MoTa { get; set; }
        public string AnhBia { get; set; }
        public int SoLuong { get; set; }
        public int IDThuongHieu { get; set; }
        [ForeignKey("IDThuongHieu")]
        public virtual ThuongHieu ThuongHieus { get; set; }
        public int IDPhanLoai { get; set; }
        [ForeignKey("IDPhanLoai")]
        public virtual PhanLoai PhanLoais { get; set; }

        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
        //public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
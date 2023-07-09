using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace Nhom8_DoAnWebBanLaptop_SangT6.Models
{
    [Table("ChiTietSanPham")]
    public class ChiTietSanPham
    {
        public int ID { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string OCUNG { get; set; }
        public string CARDMH { get; set; }
        public string MANHINH { get; set; }
        public string PIN { get; set; }
        public string TRONGLUONG { get; set; }
        public string MAUSAC { get; set; }
        public int IDMaSP { get; set; }
        [ForeignKey("IDMaSP")]
        public virtual SanPham SanPhams { get; set; }
    }
}
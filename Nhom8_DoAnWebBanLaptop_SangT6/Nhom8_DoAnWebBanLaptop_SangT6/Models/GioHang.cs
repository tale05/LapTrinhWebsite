using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom8_DoAnWebBanLaptop_SangT6.Models
{
    [Serializable] //
    public class GioHang
    {
        public SanPham SanPhams { get; set; }
        public int SoLuong { get; set; }
    }
}
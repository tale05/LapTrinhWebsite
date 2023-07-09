using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom8_DoAnWebBanLaptop_SangT6.Models;

namespace Nhom8_DoAnWebBanLaptop_SangT6.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult ChiTietSanPham(int id)
        {
            ShopDBContext db = new ShopDBContext();
            ChiTietSanPham ctsp = db.ChiTietSanPhams.Where(row => row.IDMaSP == id).FirstOrDefault();
            return View(ctsp);
        }
    }
}
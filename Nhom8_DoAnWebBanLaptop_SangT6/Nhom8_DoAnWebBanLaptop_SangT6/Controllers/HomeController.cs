using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom8_DoAnWebBanLaptop_SangT6.Models;
using System.Data.SqlClient;

namespace Nhom8_DoAnWebBanLaptop_SangT6.Controllers
{
    public class HomeController : Controller
    {
        ShopDBContext db = new ShopDBContext();
        DataClasses1DataContext db1 = new DataClasses1DataContext();
        // GET: Home
        public ActionResult Index()
        {
            
            List<SanPham> sp = db.SanPhams.ToList();
            ViewBag.sp = sp;
            return View(sp);
        }
        public ActionResult SearchTH(string thuonghieu="")
        {
            List<SanPham> sp = db.SanPhams.Where(row => row.ThuongHieus.TenTH == thuonghieu).ToList();
            return View(sp);

        }
        public ActionResult SearchNC(int ID)
        {
            List<SanPham> sp = db.SanPhams.Where(row => row.PhanLoais.ID == ID).ToList();
            return View(sp);
        }
    }
}
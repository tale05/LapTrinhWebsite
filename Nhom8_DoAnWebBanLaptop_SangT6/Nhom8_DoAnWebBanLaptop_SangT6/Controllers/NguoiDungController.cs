using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom8_DoAnWebBanLaptop_SangT6.Models;

namespace Nhom8_DoAnWebBanLaptop_SangT6.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        ShopDBContext db = new ShopDBContext();
        DataClasses1DataContext db1 = new DataClasses1DataContext();
        [HttpGet]
        public ActionResult DangNhapAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhapAdmin(FormCollection f1)
        {
            var tendn = f1["UserName"];
            var matkhau = f1["Password"];
            if (!String.IsNullOrEmpty(tendn) && !String.IsNullOrEmpty(matkhau))
            {
                TAIKHOANADMIN ad = db1.TAIKHOANADMINs.SingleOrDefault(d => d.TENTAIKHOANAD == tendn && d.MATKHAUAD == matkhau);
                if (ad != null)
                {
                    return RedirectToAction("QuanLy", "Admin");
                }
                else
                {
                    Session.Clear();
                    ViewBag.TB = "Đăng nhập không thành công, sai tên TK hoặc Password";
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            var tendn = f["UserName"];
            var matkhau = f["Password"];
            if (!String.IsNullOrEmpty(tendn) && !String.IsNullOrEmpty(matkhau))
            {
                KHACHHANG kh = db1.KHACHHANGs.SingleOrDefault(c => c.TAIKHOAN == tendn && c.MATKHAU == matkhau);
                if (kh != null)
                {
                    ViewBag.TB = "Đăng nhập thành công";
                    Session["taikhoan"] = "Tài Khoản: " + tendn;
                }   
                else
                {
                    Session.Clear();
                    ViewBag.TB = "Đăng nhập không thành công, sai tên TK hoặc Password";
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(DangKy a, string txt_diachi, string txt_email, string txt_ngaysinh)
        {
            if (ModelState.IsValid)
            {
                Models.KHACHHANG kh = new KHACHHANG();
                kh.TENKH = a.Hotenkh;
                kh.NGAYSINH = DateTime.Parse(txt_ngaysinh);
                kh.DIENTHOAI = int.Parse(a.Sodienthoai);
                kh.TAIKHOAN = a.UserName;
                kh.MATKHAU = a.Password;
                kh.EMAIL = txt_email;
                kh.DIACHI = txt_diachi;

                db1.KHACHHANGs.InsertOnSubmit(kh);
                db1.SubmitChanges();
                ViewBag.TBDN = "Đăng Ký Thành Công";
                return View();

            }
            else
            {
                return View();

            }
        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}
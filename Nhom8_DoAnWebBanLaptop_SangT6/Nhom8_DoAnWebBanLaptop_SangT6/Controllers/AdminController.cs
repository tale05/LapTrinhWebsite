using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom8_DoAnWebBanLaptop_SangT6.Models;
using System.IO;

namespace Nhom8_DoAnWebBanLaptop_SangT6.Controllers
{
    public class AdminController : Controller
    {
        ShopDBContext db = new ShopDBContext();
        // GET: Admin
        public ActionResult QuanLy(string Search="")
        {
            List<SanPham> sp = db.SanPhams.Where(row => row.TenSanPham.Contains(Search)).ToList();
            ViewBag.Search = Search;
            return View(sp);
        }

        public ActionResult Insert()
        {
            List<ThuongHieu> th = db.ThuongHieus.ToList();
            List<PhanLoai> pl = db.PhanLoais.ToList();
            ViewBag.th = th;
            ViewBag.pl = pl;
            return View();
        }
        [HttpPost]
        public ActionResult Insert(SanPham sanpham, HttpPostedFileBase AnhBia)
        {
            List<ThuongHieu> th = db.ThuongHieus.ToList();
            List<PhanLoai> pl = db.PhanLoais.ToList();
            ViewBag.th = th;
            ViewBag.pl = pl;

            string FileName = Path.GetFileName(AnhBia.FileName);

            string path = Path.Combine(Server.MapPath("~/Img"), FileName);
            AnhBia.SaveAs(path);

            sanpham.AnhBia = FileName;
            db.SanPhams.Add(sanpham);
            db.SaveChanges();
            return RedirectToAction("quanly");
        }

        public ActionResult Delete(int id)
        {
            SanPham sp = db.SanPhams.Where(row => row.ID == id).FirstOrDefault();
            return View(sp);
        }
        [HttpPost]
        public ActionResult Delete(int id, SanPham sanpham)
        {
            SanPham sp = db.SanPhams.Where(row => row.ID == id).FirstOrDefault();

            db.SanPhams.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("quanly");
        }
        public ActionResult EditSP(int id)
        {
            SanPham sp = db.SanPhams.Where(row => row.ID == id).FirstOrDefault();
            List<ThuongHieu> th = db.ThuongHieus.ToList();
            List<PhanLoai> pl = db.PhanLoais.ToList();
            ViewBag.th = th;
            ViewBag.pl = pl;
            return View(sp);
        }
        [HttpPost]
        public ActionResult EditSP(int id, SanPham sanpham, HttpPostedFileBase AnhBia)
        {
            SanPham sp = db.SanPhams.Where(row => row.ID == id).FirstOrDefault();
            List<ThuongHieu> th = db.ThuongHieus.ToList();
            List<PhanLoai> pl = db.PhanLoais.ToList();
            ViewBag.th = th;
            ViewBag.pl = pl;


            sp.TenSanPham = sanpham.TenSanPham;
            sp.GiaBan = sanpham.GiaBan;
            sp.GiaGiam = sanpham.GiaGiam;
            sp.SoLuong = sanpham.SoLuong;
            sp.IDThuongHieu = sanpham.IDThuongHieu;
            sp.IDPhanLoai= sanpham.IDPhanLoai;

            if (AnhBia !=null && AnhBia.ContentLength > 0)
            {
                string FileName = Path.GetFileName(AnhBia.FileName);
                string path = Path.Combine(Server.MapPath("~/Img"), FileName);
                AnhBia.SaveAs(path);
                sp.AnhBia = FileName;
            }
            else
            {
                sp.AnhBia = sanpham.AnhBia;
            }
            db.SaveChanges();
            return RedirectToAction("QuanLy");
        }
        public ActionResult InsertCTSP(int id)
        {
            SanPham sp = db.SanPhams.Where(row => row.ID == id).FirstOrDefault();
            ViewBag.sp = sp;
            return View();
        }
        [HttpPost]
        public ActionResult InsertCTSP( ChiTietSanPham ctsp)
        {
            db.ChiTietSanPhams.Add(ctsp);
            db.SaveChanges();
            return RedirectToAction("QuanLy");
        }

        public ActionResult Detail(int id)
        {
            ChiTietSanPham ctsp = db.ChiTietSanPhams.Where(row => row.IDMaSP == id).FirstOrDefault();
            SanPham sp = db.SanPhams.Where(row => row.ID == id).FirstOrDefault();
            ViewBag.sp = sp;
            return View(ctsp);
        }
        public ActionResult EditDetail(int id)
        {
            ChiTietSanPham ctsp = db.ChiTietSanPhams.Where(row => row.ID == id).FirstOrDefault();
            return View(ctsp);
        }
        [HttpPost]
        public ActionResult EditDetail(int id,ChiTietSanPham temp)
        {
            ChiTietSanPham ctsp = db.ChiTietSanPhams.Where(row => row.ID == id).FirstOrDefault();
            
            ctsp.CPU = temp.CPU;
            ctsp.RAM = temp.RAM;
            ctsp.OCUNG = temp.OCUNG;
            ctsp.CARDMH = temp.CARDMH;
            ctsp.MANHINH = temp.MANHINH;
            ctsp.PIN = temp.PIN;
            ctsp.TRONGLUONG = temp.TRONGLUONG;
            ctsp.MAUSAC = temp.MAUSAC;

            db.SaveChanges();
            return RedirectToAction("QuanLy");
        }

    }
}
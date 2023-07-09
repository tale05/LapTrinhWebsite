using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom8_DoAnWebBanLaptop_SangT6.Models;

namespace Nhom8_DoAnWebBanLaptop_SangT6.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        ShopDBContext db  = new ShopDBContext();
        private const string CartSession = "CartSession";

        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<GioHang>();
            if (cart != null)
            {
                list = (List<GioHang>)cart;
            }
            return View(list);
        }
        public ActionResult DeleteAll()
        {
            Session[CartSession] = null;
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            var sessionCart = (List<GioHang>)Session[CartSession];
            sessionCart.RemoveAll(x => x.SanPhams.ID == id);
            Session[CartSession] = sessionCart;
            return RedirectToAction("index");
        }
        public ActionResult Update(int id, int quantity)
        {
            SanPham product = db.SanPhams.FirstOrDefault(c => c.ID == id);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<GioHang>)cart;
                if (list.Exists(x => x.SanPhams.ID == id))
                {

                    foreach (var item in list)
                    {
                        if (item.SanPhams.ID == id)
                        {
                            item.SoLuong = quantity;
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult AddItem(int productId, int SoLuong)
        {

            SanPham product = db.SanPhams.FirstOrDefault(c => c.ID == productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<GioHang>)cart;
                if (list.Exists(x => x.SanPhams.ID == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.SanPhams.ID == productId)
                        {
                            item.SoLuong = SoLuong;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng giỏ hàng
                    var item = new GioHang();
                    item.SanPhams = product;
                    item.SoLuong = SoLuong;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new GioHang();
                item.SanPhams = product;
                item.SoLuong = SoLuong;
                var list = new List<GioHang>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        public int SoLuong { get; set; }
    }
}
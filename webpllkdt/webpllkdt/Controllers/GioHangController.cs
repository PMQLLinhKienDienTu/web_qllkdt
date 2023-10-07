using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpllkdt.Models;
using webpllkdt.Filter;

namespace webpllkdt.Controllers
{
    public class GioHangController : Controller
    {
        ShopDBContext db = new ShopDBContext();
        private const string CartSession = "CartSession";
        // GET: GioHang
        [MyAuthenFilter]
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
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
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.SanPhams.MaSP == id);
            Session[CartSession] = sessionCart;
            return RedirectToAction("index");
        }
        public ActionResult Update(int id, int quantity)
        {
            SanPham product = db.SanPhams.FirstOrDefault(c => c.MaSP == id);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.SanPhams.MaSP == id))
                {

                    foreach (var item in list)
                    {
                        if (item.SanPhams.MaSP == id)
                        {
                            item.Quantity = quantity;
                        }
                    }
                }
                //else
                //{
                //    //tạo mới đối tượng cart item
                //    var item = new CartItem();
                //    item.SanPhams = product;
                //    item.Quantity = quantity;
                //    list.Add(item);
                //}
                ////Gán vào session
                //Session[CartSession] = list;
            }
            //else
            //{
            //    //tạo mới đối tượng cart item
            //    var item = new CartItem();
            //    item.SanPhams = product;
            //    item.Quantity = quantity;
            //    var list = new List<CartItem>();
            //    list.Add(item);
            //    //Gán vào session
            //    Session[CartSession] = list;
            //}

            return RedirectToAction("Index");
        }
        public ActionResult AddItem(int productId, int quantity)
        {

            SanPham product = db.SanPhams.FirstOrDefault(c => c.MaSP == productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.SanPhams.MaSP == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.SanPhams.MaSP == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.SanPhams = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.SanPhams = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
    }
}
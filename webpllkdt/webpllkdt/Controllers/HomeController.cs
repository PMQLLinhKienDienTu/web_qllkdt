using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpllkdt.Models;

namespace webpllkdt.Controllers
{
    public class HomeController : Controller
    {
        ShopDBContext db = new ShopDBContext();
        // GET: TrangChu
        public ActionResult Index()
        {
            var sp = db.SanPhams.ToList();
            return View(sp);
        }
    }
}
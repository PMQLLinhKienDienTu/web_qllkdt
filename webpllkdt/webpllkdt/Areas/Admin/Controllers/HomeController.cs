using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpllkdt.Filter;

namespace webpllkdt.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        [AdminAuthorization]
        public ActionResult Index()
        {
            return View();
        }
    }
}
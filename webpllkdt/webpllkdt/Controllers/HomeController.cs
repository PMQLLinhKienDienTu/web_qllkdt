using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using webpllkdt.Models;

namespace webpllkdt.Controllers
{
    public class HomeController : Controller
    {
        ShopDBContext db = new ShopDBContext();
        // GET: TrangChu
        public ActionResult Index(int Page = 1)
        {
            List<SanPham> sp = db.SanPhams.ToList();
            foreach (SanPham item in sp)
            {
                if (item.HinhAnh != null && item.HinhAnh.Length > 0)
                {
                    string imagePath = Server.MapPath("~/img/HinhAnh/" + item.TenSP.Trim() + ".png");

                    // Kiểm tra xem tệp hình ảnh đã tồn tại hay chưa
                    if (!System.IO.File.Exists(imagePath))
                    {
                        // Tạo MemoryStream từ dữ liệu hình ảnh
                        MemoryStream memoryStream = new MemoryStream(item.HinhAnh);

                        // Lưu dữ liệu từ MemoryStream vào tệp hình ảnh
                        System.IO.File.WriteAllBytes(imagePath, memoryStream.ToArray());
                    }
                }
            }
            //Paging
            int NoOfRecordPerPage = 20;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sp.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (Page - 1) * NoOfRecordPerPage;
            ViewBag.Page = Page;
            ViewBag.NoOfPages = NoOfPages;

            sp = sp.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(sp);
        }

    }
}
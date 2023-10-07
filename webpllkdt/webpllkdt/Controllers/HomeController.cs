﻿using System;
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
        public ActionResult Index()
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
            return View(sp);
        }

    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpllkdt.Models;

namespace webpllkdt.Controllers
{
    public class SanPhamController : Controller
    {
        ShopDBContext db = new ShopDBContext();
        // GET: SanPham
        public ActionResult SanPhamTheoThuongHieu(string thuonghieu = "")
        {
            List<SanPham> sanpham = db.SanPhams.ToList();
            //Thương hiệu
            switch (thuonghieu)
            {
                case "Intel, AMD":
                    sanpham = sanpham.Where(r => r.MaPhanLoai == 1).ToList();
                    ViewBag.ThuongHieu = "Intel, AMD";
                    break;
                case "Kingston, Corsair, Crucial":
                    sanpham = sanpham.Where(r => r.MaPhanLoai == 2).ToList();
                    ViewBag.ThuongHieu = "Kingston, Corsair, Crucial";
                    break;
                case "Western Digital, Seagate, Samsung, Kingston":
                    sanpham = sanpham.Where(r => r.MaPhanLoai == 3).ToList();
                    ViewBag.ThuongHieu = "Western Digital, Seagate, Samsung, Kingston";
                    break;
                case "ASUS, MSI, Gigabyte, ASRock":
                    sanpham = sanpham.Where(r => r.MaPhanLoai == 4).ToList();
                    ViewBag.ThuongHieu = "ASUS, MSI, Gigabyte, ASRock";
                    break;
                case "NVIDIA, AMD (Radeon)":
                    sanpham = sanpham.Where(r => r.MaPhanLoai == 5).ToList();
                    ViewBag.ThuongHieu = "NVIDIA, AMD (Radeon)";
                    break;
                case "Corsair, EVGA, Seasonic":
                    sanpham = sanpham.Where(r => r.MaPhanLoai == 6).ToList();
                    ViewBag.ThuongHieu = "Corsair, EVGA, Seasonic";
                    break;
                case "Noctua, Cooler Master, be quiet":
                    sanpham = sanpham.Where(r => r.MaPhanLoai == 7).ToList();
                    ViewBag.ThuongHieu = "Noctua, Cooler Master, be quiet";
                    break;
                case "Dell, ASUS, LG, Samsung, Acer":
                    sanpham = sanpham.Where(r => r.MaPhanLoai == 8).ToList();
                    ViewBag.ThuongHieu = "Dell, ASUS, LG, Samsung, Acer";
                    break;
                case "Logitech, Corsair, Razer, SteelSeries":
                    sanpham = sanpham.Where(r => r.MaPhanLoai == 9).ToList();
                    ViewBag.ThuongHieu = "Logitech, Corsair, Razer, SteelSeries";
                    break;
                case "Logitech, Razer, SteelSeries, Corsair":
                    sanpham = sanpham.Where(r => r.MaPhanLoai == 10).ToList();
                    ViewBag.ThuongHieu = "Logitech, Razer, SteelSeries, Corsair";
                    break;
                default:
                    break;
            }
            return View(sanpham);
        }

        public ActionResult ChiTietSanPham(int id)
        {
            SanPham sp = db.SanPhams.Where(r => r.MaSP == id).FirstOrDefault();
            if (sp != null && sp.HinhAnh != null && sp.HinhAnh.Length > 0)
            {
                // Tạo MemoryStream từ dữ liệu hình ảnh
                MemoryStream memoryStream = new MemoryStream(sp.HinhAnh);
                string imagePath = Server.MapPath("~/img/" + sp.TenSP.Trim() + ".png");

                // Kiểm tra xem tệp hình ảnh đã tồn tại hay chưa
                if (!System.IO.File.Exists(imagePath))
                {
                    // Lưu dữ liệu từ MemoryStream vào tệp hình ảnh
                    System.IO.File.WriteAllBytes(imagePath, memoryStream.ToArray());
                }
            }
            PhanLoaiSanPham plsp = db.PhanLoaiSanPhams.Where(r => r.MaPhanLoai == sp.MaPhanLoai).FirstOrDefault();
            ViewBag.plsp = plsp.NhaSanXuat;
            return View(sp);
        }
    }
}
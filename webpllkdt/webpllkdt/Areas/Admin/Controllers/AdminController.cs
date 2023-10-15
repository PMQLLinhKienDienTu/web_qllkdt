using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using webpllkdt.Models;
using webpllkdt.Identity;
using webpllkdt.Filter;
using System.Web.Helpers;
using webpllkdt.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace webpllkdt.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        ShopDBContext db = new ShopDBContext();
        public ActionResult QuanLy(string search = "", string SortColumn = "ID", string IconClass = "fa-sort-asc", int Page = 1)
        {
            List<SanPham> sp = db.SanPhams.Where(row => row.TenSP.Contains(search)).ToList();
            ViewBag.Search = search;
            //sort  
            ViewBag.SortColum = SortColumn;
            ViewBag.IconClass = IconClass;
            if (SortColumn == "ID")
            {
                if (IconClass == "fa-sort-asc")
                {
                    sp = sp.OrderBy(row => row.MaSP).ToList();
                }
                else
                {
                    sp = sp.OrderByDescending(row => row.MaSP).ToList();
                }
            }
            else if (SortColumn == "TenSP")
            {
                if (IconClass == "fa-sort-asc")
                {
                    sp = sp.OrderBy(row => row.TenSP).ToList();
                }
                else
                {
                    sp = sp.OrderByDescending(row => row.TenSP).ToList();
                }
            }
            else if (SortColumn == "GiaTien")
            {
                if (IconClass == "fa-sort-asc")
                {
                    sp = sp.OrderBy(row => row.GiaBan).ToList();
                }
                else
                {
                    sp = sp.OrderByDescending(row => row.GiaBan).ToList();
                }
            }

            //Paging
            int NoOfRecordPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sp.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (Page - 1) * NoOfRecordPerPage;
            ViewBag.Page = Page;
            ViewBag.NoOfPages = NoOfPages;

            sp = sp.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(sp);
        }

        public ActionResult ChiTietSP(int id)
        {
            SanPham sp = db.SanPhams.Where(row => row.MaSP == id).FirstOrDefault();
            PhanLoaiSanPham plsp = db.PhanLoaiSanPhams.Where(row => row.MaPhanLoai == sp.MaPhanLoai).FirstOrDefault();
            ViewBag.plsp = plsp;
            return View(sp);
        }
        public ActionResult EditSanPham(int id)
        {
            SanPham sp = db.SanPhams.Where(row => row.MaSP == id).FirstOrDefault();
            return View(sp);
        }
        [HttpPost]
        public ActionResult EditSanPham(int ID, SanPham sp)
        {
            SanPham sanPham = db.SanPhams.Where(row => row.MaSP == ID).FirstOrDefault();
            //SanPham sp = db.SanPhams.Where(row => row.ID == id).FirstOrDefault();
            //update ChiTietSanPham
            sanPham.SoLuong = sp.SoLuong;
            sanPham.GiaNhap = sp.GiaNhap;
            sanPham.GiaBan = sp.GiaBan;
            sanPham.GhiChu = sp.GhiChu;

            db.SaveChanges();
            return RedirectToAction("quanly");
        }
        public ActionResult DeleteSanPham(int id)
        {
            SanPham sp = db.SanPhams.Where(row => row.MaSP == id).FirstOrDefault();
            return View(sp);
        }
        [HttpPost]
        public ActionResult DeleteSanPham(int id, SanPham p)
        {
            SanPham sp = db.SanPhams.Where(row => row.MaSP == id).FirstOrDefault();
            db.SanPhams.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("quanly");
        }
    }
}
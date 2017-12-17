using SadiShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SadiShop.Controllers
{
    public class AdminController : Controller
    {
        dbQLQuanAoDataContext data = new dbQLQuanAoDataContext();
        // GET: Admin
        //----------------------------------------------NHA SAN XUAT----------------------------------------------
        public ActionResult NhaSanXuat()
        {
            return View(data.NhanSanXuats.ToList());
        }

        [HttpGet]
        public ActionResult ThemMoiNhaSanXuat()
        {
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoiNhaSanXuat(NhanSanXuat sp)
        {
            data.NhanSanXuats.InsertOnSubmit(sp);
            data.SubmitChanges();
            return RedirectToAction("NhaSanXuat");
        }

        public ActionResult ChiTietNhaSanXuat(string id)
        {
            NhanSanXuat sp = data.NhanSanXuats.SingleOrDefault(n => n.MaNhaSanXuat == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }

        [HttpGet]
        public ActionResult XoaNhaSanXuat(string id)
        {
            NhanSanXuat sp = data.NhanSanXuats.SingleOrDefault(n => n.MaNhaSanXuat == id);
            //ViewBag.MaSanPham = sp.MaSanPham;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }

        [HttpPost, ActionName("XoaNhaSanXuat")]
        public ActionResult XacNhanXoaNhaSanXuat(string id)
        {
            NhanSanXuat sp = data.NhanSanXuats.SingleOrDefault(n => n.MaNhaSanXuat == id);
            ViewBag.MaNhaSanXuat = sp.MaNhaSanXuat;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.NhanSanXuats.DeleteOnSubmit(sp);
            data.SubmitChanges();
            return RedirectToAction("NhaSanXuat");
        }

        [HttpGet]
        public ActionResult SuaNhaSanXuat(string id)
        {
            NhanSanXuat sp = data.NhanSanXuats.SingleOrDefault(n => n.MaNhaSanXuat == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaNhaSanXuat(NhanSanXuat sp)
        {

            if (ModelState.IsValid)
            {
                NhanSanXuat sp1 = data.NhanSanXuats.SingleOrDefault(n => n.MaNhaSanXuat == sp.MaNhaSanXuat);
                if (sp1 == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                sp1.TenNhaSanXuat = sp.TenNhaSanXuat;
                sp1.QuocGia = sp.QuocGia;
                data.SubmitChanges();
            }
            return RedirectToAction("NhaSanXuat");
        }
        //----------------------------------------------DON HANG--------------------------------------------------
        public ActionResult QuanLyDonHangChuaDyet()
        {
            return View(data.DonDatHangs.Where(n => n.MaTinhTrang == 1).ToList());
        }

        public ActionResult DaDuyet(int MaDonDatHang = 0)
        {
            DonDatHang ddh = data.DonDatHangs.SingleOrDefault(n => n.MaDonDatHang == MaDonDatHang);
            if(ddh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ddh.MaTinhTrang = 2;
            data.SubmitChanges();
            return Redirect("QuanLyDonHangChuaDyet");
        }

        public ActionResult QuanLyDonHangDaDyet()
        {
            return View(data.DonDatHangs.Where(n => n.MaTinhTrang != 1 && n.MaTinhTrang!=4).ToList());
        }

        public ActionResult DaDuyet1(int MaDonDatHang = 0)
        {
            DonDatHang ddh = data.DonDatHangs.SingleOrDefault(n => n.MaDonDatHang == MaDonDatHang);
            if (ddh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ddh.MaTinhTrang = 3;
            data.SubmitChanges();
            return Redirect("QuanLyDonHangDaDyet");
        }

        public ActionResult ChiTietDonHang(int id)
        {
            var sp = data.ChiTietDonDatHangs.Where(n => n.MaDonDatHang == id).ToList();
            //ViewBag.MaSanPham = sp.MaSanPham;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }

        [HttpGet]
        public ActionResult XoaDonHang(int id)
        {
            DonDatHang sp = data.DonDatHangs.SingleOrDefault(n => n.MaDonDatHang == id);
            //ViewBag.MaSanPham = sp.MaSanPham;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }

        [HttpPost, ActionName("XoaDonHang")]
        public ActionResult XacNhanXoaDonHang(int id)
        {
            DonDatHang sp = data.DonDatHangs.SingleOrDefault(n => n.MaDonDatHang == id);
            var ct = data.ChiTietDonDatHangs.Where(n => n.MaDonDatHang == id).ToList();
            ViewBag.MaThuongHieuSanPham = sp.MaDonDatHang;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.ChiTietDonDatHangs.DeleteAllOnSubmit(ct);
            data.DonDatHangs.DeleteOnSubmit(sp);
            data.SubmitChanges();
            return RedirectToAction("QuanLyDonHangChuaDyet");
        }
        //----------------------------------------------TAIKHOAN-------------------------------------------------
    }
}

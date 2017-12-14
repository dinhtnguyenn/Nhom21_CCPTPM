using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SadiShop.Models;

using PagedList;
using PagedList.Mvc;
namespace SadiShop.Controllers
{
    public class ShopController : Controller
    {
	//-------------------------------HIỂN THỊ SẢN PHẨM THEO LOẠI--------------------------------
        public ActionResult HienThiSanPhamTheoLoaiNu(string id, int? page)
        {
            //page 
            int pageSize = 6;
            int pageNum = (page ?? 1);
            var tenloai = data.LoaiSanPhams.SingleOrDefault(n => n.MaLoai == id);
            ViewBag.tenloai = tenloai.TenLoai;
            //hienthisanpham

            var sanpham = from sp in data.SanPhams where sp.MaLoai == id select sp;
            int sl = 0;
            foreach (var count in sanpham)
            {
                sl++;
            }
            ViewBag.soluong = sl;
            return View(sanpham.ToPagedList(pageNum, pageSize));
        }

        public ActionResult HienThiSanPhamTheoLoaiNam(string id, int? page)
        {
            //page 
            int pageSize = 6;
            int pageNum = (page ?? 1);
            var tenloai = data.LoaiSanPhams.SingleOrDefault(n => n.MaLoai == id);
            ViewBag.tenloai = tenloai.TenLoai;
            //hienthisanpham
            var sanpham = from sp in data.SanPhams where sp.MaLoai == id select sp;
            int sl = 0;
            foreach (var count in sanpham)
            {
                sl++;
            }
            ViewBag.soluong = sl;
            return View(sanpham.ToPagedList(pageNum, pageSize));
        }

        public ActionResult HienThiSanPhamTheoLoaiGiay(string id, int? page)
        {
            //page 
            int pageSize = 6;
            int pageNum = (page ?? 1);
            var tenloai = data.LoaiSanPhams.SingleOrDefault(n => n.MaLoai == id);
            ViewBag.tenloai = tenloai.TenLoai;
            //hienthisanpham
            var sanpham = from sp in data.SanPhams where sp.MaLoai == id select sp;
            int sl = 0;
            foreach (var count in sanpham)
            {
                sl++;
            }
            ViewBag.soluong = sl;
            return View(sanpham.ToPagedList(pageNum, pageSize));
        }

        public ActionResult HienThiSanPhamTheoLoaiPhuKien(string id, int? page)
        {
            //page 
            int pageSize = 6;
            int pageNum = (page ?? 1);
            var tenloai = data.LoaiSanPhams.SingleOrDefault(n => n.MaLoai == id);
            ViewBag.tenloai = tenloai.TenLoai;
            //hienthisanpham
            var sanpham = from sp in data.SanPhams where sp.MaLoai == id select sp;
            int sl = 0;
            foreach (var count in sanpham)
            {
                sl++;
            }
            ViewBag.soluong = sl;
            return View(sanpham.ToPagedList(pageNum, pageSize));
        }	
	}
}

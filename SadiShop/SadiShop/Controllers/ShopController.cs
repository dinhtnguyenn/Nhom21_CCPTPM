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
		dbQLQuanAoDataContext data = new dbQLQuanAoDataContext();
		//------------------------------HIỂN THỊ CHI TIẾT--------------------------------
        public ActionResult ChiTiet(string id)
        {
            var sanpham = data.SanPhams.SingleOrDefault(n => n.MaSanPham == id);
            var nhasanxuat = data.NhanSanXuats.SingleOrDefault(n => n.MaNhaSanXuat == sanpham.MaNhaSanXuat);
            ViewBag.nsx = nhasanxuat.TenNhaSanXuat;
            return View(sanpham);
        }
	}
}

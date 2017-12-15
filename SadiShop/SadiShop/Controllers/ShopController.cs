﻿using System;
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
		
		public ActionResult XemNhanh(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }
            var sanpham = data.SanPhams.SingleOrDefault(n => n.MaSanPham == id);
            var nhasanxuat = data.NhanSanXuats.SingleOrDefault(n => n.MaNhaSanXuat == sanpham.MaNhaSanXuat);
            ViewBag.nsx = nhasanxuat.TenNhaSanXuat;
            //var sanpham = (from sp
            //               in data.SanPhams
            //               where sp.MaSanPham == id
            //               select sp
            //               ).SingleOrDefault();
            return PartialView("XemNhanh", sanpham);
			
			//--------------------------------XU HƯỚNG MỚI--------------------------------
        public ActionResult XuHuongMoi()
        {
            var sanpham = from sp in data.SanPhams orderby sp.MaSanPham ascending select sp;
            return PartialView(sanpham);
        }
        }
	}
}

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
		
		//------------------------------TÌM KIỂM-----------------------------------------
        [HttpPost]
        public ActionResult KetQuaTimKiem(int? page, FormCollection f)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            var lstSP = data.SanPhams.Where(n => n.TenSanPham.Contains(sTuKhoa)).ToList().OrderByDescending(n => n.MaSanPham).ToPagedList(pageNumber, pageSize);
            if (lstSP.Count == 0)
            {
                ViewBag.ThongBao = "Không có sản phẩm phù hợp";
            }
            else
            {
                ViewBag.ThongBao = "Đã tìm thấy " + lstSP.Count + " kết quả!";
            }

            return View(lstSP);
        }

        [HttpGet]
        public ActionResult KetQuaTimKiem(int? page, string sTuKhoa)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<SanPham> sp = data.SanPhams.Where(n => n.TenSanPham.Contains(sTuKhoa)).ToList();
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            if (sp.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào :(";
                return View(data.SanPhams.OrderBy(n => n.TenSanPham).ToPagedList(pageNumber, pageSize));
            }
            else
            {
                ViewBag.ThongBao = "Đã tìm thấy " + sp.Count + " kết quả";
                return View(sp.OrderBy(n => n.TenSanPham).ToPagedList(pageNumber, pageSize));
            }
        }
	}
}

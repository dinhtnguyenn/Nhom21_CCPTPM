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
        //--------------------------------HIỂN THỊ SẢN PHẨM TRANG INDEX--------------------------------
        private List<SanPham> Laysanphammoi(int count)
        {
            return data.SanPhams.OrderByDescending(a => a.MaSanPham).Take(count).ToList();
        }
		
        // GET: Shop
        public ActionResult Index()
        {
            var sanphammoi = Laysanphammoi(6);
            return View(sanphammoi);
        }
		  //---------------------------LOẠI SẢN PHẨM TRÊN MENU ----------------------------------
        public ActionResult LoaisanphamNu()
        {
            var loai = from l in data.LoaiSanPhams where l.MaLoaiCha == "L01" select l;
            return PartialView(loai);
        }

        public ActionResult LoaisanphamNam()
        {
            var loai = from l in data.LoaiSanPhams where l.MaLoaiCha == "L02" select l;
            return PartialView(loai);
        }

        //----------------------------------GIÀY----------------------------------------
        public ActionResult LoaisanphamGiay()
        {
            var loai = from l in data.LoaiSanPhams where l.MaLoaiCha == "L03" select l;
            return PartialView(loai);
        }

        //----------------------------------------------KHÁC--------------------------------------------
        public ActionResult LoaisanphamPhuKien()
        {
            var loai = from l in data.LoaiSanPhams where l.MaLoaiCha == "L04" select l;
            return PartialView(loai);
        }



	}
}

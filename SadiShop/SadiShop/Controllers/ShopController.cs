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

//--------------------------------SẢN PHẨM SALE--------------------------------
        private List<SanPham> SanPhamSale(int count)
        {
            return data.SanPhams.OrderByDescending(a => a.GiaBan).Take(count).ToList();
        }

        public ActionResult Sale()
        {
            var sanphamsale = SanPhamSale(10);
            return View(sanphamsale);
        }

//-------------------------------ABOUT + LIÊN HỆ--------------------------------
	public ActionResult About()
        {
            return View();
        }

        public ActionResult LienHe()
        {
            return View();
        }


	}
}

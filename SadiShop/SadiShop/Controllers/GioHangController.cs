using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SadiShop.Models;
using Microsoft.AspNet.Identity;

namespace SadiShop.Controllers
{
    public class GioHangController : Controller
    {
		dbQLQuanAoDataContext data = new dbQLQuanAoDataContext();
		
        public ActionResult LichSuDonHang()
        {
            return View(data.DonDatHangs.Where(n => n.MaTaiKhoan == User.Identity.GetUserId()).ToList());
        }
    }
}
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

        public ActionResult XacNhanDonHang()
        {
            return View();
        }

	[HttpGet]
        [Authorize]
        public ActionResult ThongTinKhachHang()
        {
            var tt = data.AspNetUsers.SingleOrDefault(n => n.Id == User.Identity.GetUserId());
            if(tt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tt);
        }

        [HttpPost]
        public ActionResult ThongTinKhachHang(AspNetUser user)
        {
            var user1 = data.AspNetUsers.SingleOrDefault(n => n.Id == user.Id);
            if(user1 == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            user1.FullName = user.FullName;
            user1.PhoneNumber = user.PhoneNumber;
            user1.Address = user.Address;
            data.SubmitChanges();
            return Redirect("DatHang");
        }

    }
}
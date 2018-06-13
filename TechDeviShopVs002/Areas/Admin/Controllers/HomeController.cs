using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechDeviShopVs002.Common;
using TechDeviShopVs002.DAL;

namespace TechDeviShopVs002.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Profile()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var user = new UserDAL().ViewDetail(session.UserID);
            return View(user);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechDeviShopVs002.Common;
using TechDeviShopVs002.Models;
using TechDeviShopVs002.DAL;

namespace TechDeviShopVs002.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            var CusUserSession = (CusUserLogin)Session[CommonConstants.CusUserSession];
            ViewBag.OrderHistory = new OrderDAL().OrderHistory(CusUserSession.CustomerID);
            ViewBag.OngoingOrders = new OrderDAL().OngoingOrders(CusUserSession.CustomerID);
            var model = new CustomerDAL().ViewDetail(CusUserSession.CustomerID);
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangePass()
        {
            var CusUserSession = (CusUserLogin)Session[CommonConstants.CusUserSession];

            string OldPass = String.Format("{0}", Request.Form["OldPassword"]);
            string NewPass = String.Format("{0}", Request.Form["NewPassword"]);

            try 
            {
                var cust = new CustomerDAL().ViewDetail(CusUserSession.CustomerID);

                if (cust.Password == Encryptor.MD5Hash(OldPass))
                {
                    cust.Password = Encryptor.MD5Hash(NewPass);
                    var result = new CustomerDAL().Update(cust);
                }
                return RedirectToAction("Index", "Profile", new { message = "doi-mat-khau-thanh-cong" });
            }
            catch(Exception)
            {
                //return Redirect("/loi-doi-mat-khau");
                ModelState.AddModelError("","Doi mat khau khong thanh cong");
            }
            return View();
        }

        
    }
}
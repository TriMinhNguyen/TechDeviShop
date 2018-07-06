using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechDeviShopVs002.Common;
using TechDeviShopVs002.DAL;
using TechDeviShopVs002.Models;

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

        public ActionResult ProfileInfo()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var user = new UserDAL().ViewDetail(session.UserID);
            return View(user);
        }

        public ActionResult ChangeUserInfo()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];

            var model = new UserDAL().ViewDetail(session.UserID);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeUserInfo([Bind(Include = "UserID,Email,Name,Gender,Birthday,Phone,Address")] User user)
        {
            var model = new UserDAL().ViewDetail(user.UserID);
            try
            {
                model.Name = user.Name;
                model.Email = user.Email;
                model.Gender = user.Gender;
                model.Birthday = user.Birthday;
                model.Phone = user.Phone;
                model.Address = user.Address;
                var _dal = new UserDAL();

                var _result = _dal.Update(model);

                return RedirectToAction("ProfileInfo", "Home");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Cập nhật thông tin ko thành công");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangePass()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];

            string OldPass = String.Format("{0}", Request.Form["OldPassword"]);
            string NewPass = String.Format("{0}", Request.Form["NewPassword"]);

            try
            {
                var cust = new UserDAL().ViewDetail(session.UserID);

                if (cust.Password == Encryptor.MD5Hash(OldPass))
                {
                    cust.Password = Encryptor.MD5Hash(NewPass);
                    var result = new UserDAL().Update(cust);
                }
                return RedirectToAction("ProfileInfo", "Home");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Doi mat khau khong thanh cong");
            }
            return View();
        }
    }
}
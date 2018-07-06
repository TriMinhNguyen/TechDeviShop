using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechDeviShopVs002.Common;
using TechDeviShopVs002.Models;
using TechDeviShopVs002.DAL;
using TechDeviShopVs002.Models.ViewModel;
using Common;
using System.Configuration;
using System.Xml.Linq;

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

        public ActionResult ChangeInfo()
        {
            var CusUserSession = (CusUserLogin)Session[CommonConstants.CusUserSession];

            var customer = new CustomerDAL().ViewDetail(CusUserSession.CustomerID);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeInfo([Bind(Include = "CustomerID,CustomerEmail,CustomerName,CustomerGender,CustomerBirthday,CustomerPhone,CustomerAddress,OrtherDetail")] Customer customer)
        {
            var cust = new CustomerDAL().ViewDetail(customer.CustomerID);
            try
            {
                cust.CustomerName = customer.CustomerName;
                cust.CustomerEmail = customer.CustomerEmail;
                cust.CustomerGender = customer.CustomerGender;
                cust.CustomerBirthday = customer.CustomerBirthday;
                cust.CustomerPhone = customer.CustomerPhone;
                cust.CustomerAddress = customer.CustomerAddress;
                cust.OrtherDetail = customer.OrtherDetail;
                var _dal = new CustomerDAL();

                var _result = _dal.Update(cust);

                return RedirectToAction("Index", "Profile");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Cập nhật thông tin ko thành công");
            }
            return View(customer);
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
            catch (Exception)
            {
                ModelState.AddModelError("", "Doi mat khau khong thanh cong");
            }
            return View();
        }

        public ActionResult HistoryOrderDetail(int id)
        {
            ViewBag.HOrderDetail = new OrderDAL().ViewDetail(id);

            var listSCD = new OrderDetailsDAL().ListByOrderID(id).ToList();

            return View(listSCD);
        }

        public ActionResult OngoingOrderDetail(int id)
        {
            ViewBag.OngoingOD = new OrderDAL().ViewDetail(id);

            var listSCD = new OrderDetailsDAL().ListByOrderID(id).ToList();

            return View(listSCD);
        }

        public ActionResult OrderCancel(int id)
        {
            var CusUserSession = (CusUserLogin)Session[TechDeviShopVs002.Common.CommonConstants.CusUserSession];

            var cust = new CustomerDAL().ViewDetail(CusUserSession.CustomerID);

            var order = new OrderDAL().ViewDetail(id);

            try
            {
                var listOrderDetail = new OrderDetailsDAL().ListByOrderID(id);

                decimal total = 0;
                foreach (var item in listOrderDetail)
                {
                    //calculated total price;
                    total += (item.Product.PromotionPrice.GetValueOrDefault(0) * (decimal)item.Quantity);
                }

                order.OrderStatusID = 5;
                order.ModifiedDate = DateTime.Now;
                var _result = new OrderDAL().Update(order);

                string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Client/template/neworder.html"));

                content = content.Replace("{{CustomerName}}", order.CusName);
                content = content.Replace("{{Phone}}", order.CusPhone);
                content = content.Replace("{{Email}}", order.CusEmail);
                content = content.Replace("{{Address}}", order.Address);
                content = content.Replace("{{OrderID}}", order.OrderID.ToString());
                content = content.Replace("{{Total}}", total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(order.CusEmail, "Đơn hàng bị hủy bỏ từ OnlineShop", content);
                new MailHelper().SendMail(toEmail, "Đơn hàng bị hủy bỏ từ OnlineShop", content);
            }
            catch (Exception)
            {
                //ghi log
                return Redirect("/loi-huy-bo");
            }
            return Redirect("/huy-bo-thanh-cong");
        }

        public ActionResult CancelOrderSuccess()
        {
            return View();
        }

        public ActionResult CancelOrderError()
        {
            return View();
        }
    }
}
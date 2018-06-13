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
            return View();
        }
        
        
    }
}
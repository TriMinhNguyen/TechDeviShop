using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechDeviShopVs002.Common;
using TechDeviShopVs002.DAL;
using TechDeviShopVs002.Models;
using TechDeviShopVs002.Models.ViewModel;

namespace TechDeviShopVs002.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var productDal = new ProductDAL();
            ViewBag.NewProducts = productDal.ListNewProduct(4);
            ViewBag.ListFeatureProducts = productDal.ListFeatureProduct(4);
            ViewBag.Supplier = new SupplierDAL().ListAll();
            ViewBag.Listproduct = productDal.ListALl();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDAL().ListByGroupId(1);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = new MenuDAL().ListByGroupId(2);
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult HeaderMiniCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }

        public ActionResult Banner()
        {
            var model = new SlideDAL().ListALl();
            return PartialView(model);
        }

        public ActionResult Footer()
        {
            var model = new FooterDAL().GetFooter();
            return PartialView(model);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechDeviShopVs002.DAL;

namespace TechDeviShopVs002.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var productDal = new ProductDAL();
            ViewBag.NewProducts = productDal.ListNewProduct(4);
            ViewBag.ListFeatureProducts = productDal.ListFeatureProduct(4);
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

        public ActionResult BannerSlide()
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
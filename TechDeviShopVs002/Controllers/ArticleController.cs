using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechDeviShopVs002.DAL;

namespace TechDeviShopVs002.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            var articles = new ArticleDAL().ListAll();
            ViewBag.articleCategory = new ArticleCategoryDAL().ListAll();
            return View(articles);
        }

        public ActionResult Details(int id)
        {
            var articles = new ArticleDAL().ViewDetail(id);
            return View(articles);
        }

        [ChildActionOnly]
        public PartialViewResult ArticleCategory()
        {
            var model = new ArticleCategoryDAL().ListAll();
            return PartialView(model);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechDeviShopVs002.DAL;
using TechDeviShopVs002.Models;

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

        public ActionResult ArticleByCate(int id)
        {
            var articles = new ArticleDAL().ListByArticleCategory(id);
            ViewBag.articleCategory = new ArticleCategoryDAL().ListAll();
            return View(articles);
        }

        public ActionResult Details(int id)
        {
            var articles = new ArticleDAL().ViewDetail(id);
            ViewBag.Comment = new CommentDAL().ListByArticleID(articles.ArticleID);
            return View(articles);
        }

        [ChildActionOnly]
        public PartialViewResult ArticleCategory()
        {
            var model = new ArticleCategoryDAL().ListAll();
            return PartialView(model);
        }

        public ActionResult ArticleComment(string CommentContent, string Name, string Email, int ArticleID)
        {
            //string productComment = String.Format("{0}", Request.Form["CommentContent"]);
            //string CommentName = String.Format("{0}", Request.Form["Name"]);
            //string CommentEmail = String.Format("{0}", Request.Form["Email"]);
            var pComment = new Comment();
            if (ModelState.IsValid)
            {
                pComment.ArticleID = ArticleID;
                pComment.Email = Email;
                pComment.Name = Name;
                pComment.CommentContent = CommentContent;
                pComment.IsActive = true;
                var result = new CommentDAL().Insert(pComment);
                if (result > 0)
                {
                    return RedirectToAction("Details", "Article", new { id = ArticleID});
                }
                else
                {
                    ModelState.AddModelError("", "Thêm bình luận ko thành công");
                }
            }
            return View(pComment);
        }
    }
}
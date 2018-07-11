using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechDeviShopVs002.DAL;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/Articles
        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.ArticleCategory);
            return View(articles.ToList());
        }

        // GET: Admin/Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var article = new ArticleDAL().ViewDetail(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Admin/Articles/Create
        public ActionResult Create()
        {
            ViewBag.ArticleCategoryID = new SelectList(db.ArticleCategories, "ArticleCategoryID", "ArticleCategoryName");
            return View();
        }

        // POST: Admin/Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleID,ArticleCategoryID,Title,MetaTitle,ArticleContent,Image,Tag,ViewCount,Votes,TotalRating,Approved,ApprovedUser,ApprovedDate,CreateDate,CreateUser,ModifiedDate,ModifiedUser,MetalKeywords,MetalDescriptions,IsActive")] Article article)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new ArticleDAL();

                article.CreateUser = UserSession.UserID;
                if(article.Approved == true)
                {
                    article.ApprovedUser = UserSession.UserID;
                    article.ApprovedDate = DateTime.Now;
                }
                int id = _dal.Insert(article);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Articles");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm bài viết ko thành công");
                }
            }

            ViewBag.ArticleCategoryID = new SelectList(db.ArticleCategories, "ArticleCategoryID", "ArticleCategoryName", article.ArticleCategoryID);
            return View(article);
        }

        // GET: Admin/Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var article = new ArticleDAL().ViewDetail(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleCategoryID = new SelectList(db.ArticleCategories, "ArticleCategoryID", "ArticleCategoryName", article.ArticleCategoryID);
            article.ArticleContent = System.Web.HttpUtility.HtmlDecode(article.ArticleContent);
            return View(article);
        }

        // POST: Admin/Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleID,ArticleCategoryID,Title,MetaTitle,ArticleContent,Image,Tag,ViewCount,Votes,TotalRating,Approved,ApprovedUser,ApprovedDate,CreateDate,CreateUser,ModifiedDate,ModifiedUser,MetalKeywords,MetalDescriptions,IsActive")] Article article)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new ArticleDAL();

                article.ModifiedUser = UserSession.UserID;

                if (article.Approved == true && article.ApprovedUser == null)
                {
                    article.ApprovedUser = UserSession.UserID;
                    article.ApprovedDate = DateTime.Now;
                }

                var _result = _dal.Update(article);
                if (_result)
                {
                    return RedirectToAction("Index", "Articles");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật bài viết ko thành công");
                }
            }
            ViewBag.ArticleCategoryID = new SelectList(db.ArticleCategories, "ArticleCategoryID", "ArticleCategoryName", article.ArticleCategoryID);
            return View(article);
        }

        // GET: Admin/Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var article = new ArticleDAL().ViewDetail(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Admin/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new ArticleDAL().Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

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
    public class ArticleImagesController : Controller
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/ArticleImages
        public ActionResult Index()
        {
            var articleImages = db.ArticleImages.Include(a => a.Article);
            return View(articleImages.ToList());
        }

        // GET: Admin/ArticleImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var articleImage = new ArticleImageDAL().ViewDetail(id);
            if (articleImage == null)
            {
                return HttpNotFound();
            }
            return View(articleImage);
        }

        // GET: Admin/ArticleImages/Create
        public ActionResult Create()
        {
            ViewBag.ArticleID = new SelectList(db.Articles, "ArticleID", "Title");
            return View();
        }

        // POST: Admin/ArticleImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleImageID,ArticleID,MetaTitle,Description,Image,CreateDate,CreateUser,ModifiedDate,ModifiedUser,IsActive")] ArticleImage articleImage)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new ArticleImageDAL();

                articleImage.CreateUser = UserSession.UserID;

                int id = _dal.Insert(articleImage);
                if (id > 0)
                {
                    return RedirectToAction("Index", "ArticleImages");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm ảnh bài viết ko thành công");
                }
            }

            ViewBag.ArticleID = new SelectList(db.Articles, "ArticleID", "Title", articleImage.ArticleID);
            return View(articleImage);
        }

        // GET: Admin/ArticleImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var articleImage = new ArticleImageDAL().ViewDetail(id);
            if (articleImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleID = new SelectList(db.Articles, "ArticleID", "Title", articleImage.ArticleID);
            return View(articleImage);
        }

        // POST: Admin/ArticleImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleImageID,ArticleID,MetaTitle,Description,Image,CreateDate,CreateUser,ModifiedDate,ModifiedUser,IsActive")] ArticleImage articleImage)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new ArticleImageDAL();

                articleImage.ModifiedUser = UserSession.UserID;

                var _result = _dal.Update(articleImage);
                if (_result)
                {
                    return RedirectToAction("Index", "ArticleImages");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật ảnh bài viết ko thành công");
                }
            }
            ViewBag.ArticleID = new SelectList(db.Articles, "ArticleID", "Title", articleImage.ArticleID);
            return View(articleImage);
        }

        // GET: Admin/ArticleImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var articleImage = new ArticleImageDAL().ViewDetail(id);
            if (articleImage == null)
            {
                return HttpNotFound();
            }
            return View(articleImage);
        }

        // POST: Admin/ArticleImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new ArticleImageDAL().Delete(id);
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

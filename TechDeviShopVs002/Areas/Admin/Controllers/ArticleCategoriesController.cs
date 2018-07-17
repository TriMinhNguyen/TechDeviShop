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
    public class ArticleCategoriesController : Controller
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/ArticleCategories
        public ActionResult Index()
        {
            return View(db.ArticleCategories.ToList());
        }

        // GET: Admin/ArticleCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var articleCategory = new ArticleCategoryDAL().ViewDetail(id);
            if (articleCategory == null)
            {
                return HttpNotFound();
            }
            return View(articleCategory);
        }

        // GET: Admin/ArticleCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ArticleCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleCategoryID,ArticleCategoryName,Description,Image,MetaTitle,ParentID,DisplayOrder,SeoTitle,MetaDescription,MetaKeywords,CreateDate,CreateUser,ModifiedDate,ModifiedUser,IsActive")] ArticleCategory articleCategory)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new ArticleCategoryDAL();

                articleCategory.CreateUser = UserSession.UserID;

                int id = _dal.Insert(articleCategory);
                if (id > 0)
                {
                    return RedirectToAction("Index", "ArticleCategories");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm danh muc bài viết ko thành công");
                }
            }

            return View(articleCategory);
        }

        // GET: Admin/ArticleCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var articleCategory = new ArticleCategoryDAL().ViewDetail(id);
            if (articleCategory == null)
            {
                return HttpNotFound();
            }
            return View(articleCategory);
        }

        // POST: Admin/ArticleCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleCategoryID,ArticleCategoryName,Description,Image,MetaTitle,ParentID,DisplayOrder,SeoTitle,MetaDescription,MetaKeywords,CreateDate,CreateUser,ModifiedDate,ModifiedUser,IsActive")] ArticleCategory articleCategory)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new ArticleCategoryDAL();

                articleCategory.ModifiedUser = UserSession.UserID;

                var _result = _dal.Update(articleCategory);
                if (_result)
                {
                    return RedirectToAction("Index", "ArticleCategories");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật danh muc bài viết ko thành công");
                }
            }
            return View(articleCategory);
        }

        // GET: Admin/ArticleCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var articleCategory = new ArticleCategoryDAL().ViewDetail(id);
            if (articleCategory == null)
            {
                return HttpNotFound();
            }
            return View(articleCategory);
        }

        // POST: Admin/ArticleCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //new ArticleCategoryDAL().Delete(id);

            var aCate = new ArticleCategoryDAL().ViewDetail(id);
            aCate.IsActive = false;
            var _dal = new ArticleCategoryDAL();
            var _result = _dal.Update(aCate);

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

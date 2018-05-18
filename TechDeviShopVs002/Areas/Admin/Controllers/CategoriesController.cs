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
    public class CategoriesController : BaseController
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = new CategoryDAL().ViewDetail(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName,MetaTitle,ParentID,DisplayOrder,SeoTitle,CreateDate,CreateBy,ModifiedDate,ModifiedBy,MetalKeywords,MetalDescriptions,IsActive,ShowOnHome")] Category category)
        {
            if (ModelState.IsValid)
            {
                var _dal = new CategoryDAL();

                int id = _dal.Insert(category);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Categories");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm danh muc ko thành công");
                }
            }

            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = new CategoryDAL().ViewDetail(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName,MetaTitle,ParentID,DisplayOrder,SeoTitle,CreateDate,CreateBy,ModifiedDate,ModifiedBy,MetalKeywords,MetalDescriptions,IsActive,ShowOnHome")] Category category)
        {
            if (ModelState.IsValid)
            {
                var _dal = new CategoryDAL();
                var _result = _dal.Update(category);
                if (_result)
                {
                    return RedirectToAction("Index", "Categories");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật danh muc ko thành công");
                }
            }
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = new CategoryDAL().ViewDetail(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new CategoryDAL().Delete(id);
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

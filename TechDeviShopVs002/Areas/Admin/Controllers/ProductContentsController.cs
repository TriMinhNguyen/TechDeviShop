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
    public class ProductContentsController : BaseController
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/ProductContents
        public ActionResult Index()
        {
            return View(db.ProductContents.ToList());
        }

        // GET: Admin/ProductContents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productContent = new ProductContentDAL().ViewDetail(id);
            if (productContent == null)
            {
                return HttpNotFound();
            }
            return View(productContent);
        }

        // GET: Admin/ProductContents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductContents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductContentID,ProductName,MetaTitle,Description,Image,CategoryID,Detail,Warranty,CreateDate,CreateBy,ModifiedDate,ModifiedBy,MetalKeywords,MetalDescriptions,Status,TopHot,ViewCount,Tag")] ProductContent productContent)
        {
            if (ModelState.IsValid)
            {
                var _dal = new ProductContentDAL();

                int id = _dal.Insert(productContent);
                if (id > 0)
                {
                    return RedirectToAction("Index", "ProductContents");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm product content ko thành công");
                }
            }

            return View(productContent);
        }

        // GET: Admin/ProductContents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productContent = new ProductContentDAL().ViewDetail(id);
            if (productContent == null)
            {
                return HttpNotFound();
            }
            return View(productContent);
        }

        // POST: Admin/ProductContents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductContentID,ProductName,MetaTitle,Description,Image,CategoryID,Detail,Warranty,CreateDate,CreateBy,ModifiedDate,ModifiedBy,MetalKeywords,MetalDescriptions,Status,TopHot,ViewCount,Tag")] ProductContent productContent)
        {
            if (ModelState.IsValid)
            {
                var _dal = new ProductContentDAL();
                var _result = _dal.Update(productContent);
                if (_result)
                {
                    return RedirectToAction("Index", "ProductContents");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật product content ko thành công");
                }
            }
            return View(productContent);
        }

        // GET: Admin/ProductContents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productContent = new ProductContentDAL().ViewDetail(id);
            if (productContent == null)
            {
                return HttpNotFound();
            }
            return View(productContent);
        }

        // POST: Admin/ProductContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new ProductContentDAL().Delete(id);
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

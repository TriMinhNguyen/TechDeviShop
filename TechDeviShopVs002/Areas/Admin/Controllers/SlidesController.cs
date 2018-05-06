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
    public class SlidesController : Controller
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/Slides
        public ActionResult Index()
        {
            return View(db.Slides.ToList());
        }

        // GET: Admin/Slides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var slide = new SlideDAL().ViewDetail(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // GET: Admin/Slides/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Slides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SlideID,Image,DisplayOrder,Link,Description,CreateDate,CreateBy,ModifiedDate,ModifiedBy,IsActive")] Slide slide)
        {
            if (ModelState.IsValid)
            {
                var _dal = new SlideDAL();

                int id = _dal.Insert(slide);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Slides");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm slide ko thành công");
                }
            }

            return View(slide);
        }

        // GET: Admin/Slides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var slide = new SlideDAL().ViewDetail(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: Admin/Slides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SlideID,Image,DisplayOrder,Link,Description,CreateDate,CreateBy,ModifiedDate,ModifiedBy,IsActive")] Slide slide)
        {
            if (ModelState.IsValid)
            {
                var _dal = new SlideDAL();
                var _result = _dal.Update(slide);
                if (_result)
                {
                    return RedirectToAction("Index", "Slides");
                }
                else
                {
                    ModelState.AddModelError("", "Cập slide ko thành công");
                }
            }
            return View(slide);
        }

        // GET: Admin/Slides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var slide = new SlideDAL().ViewDetail(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: Admin/Slides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new SlideDAL().Delete(id);
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

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
    public class FootersController : Controller
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/Footers
        public ActionResult Index()
        {
            return View(db.Footer.ToList());
        }

        // GET: Admin/Footers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var footer = new FooterDAL().ViewDetail(id);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // GET: Admin/Footers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Footers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FooterID,Content,Status")] Footer footer)
        {
            if (ModelState.IsValid)
            {
                db.Footer.Add(footer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(footer);
        }

        // GET: Admin/Footers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var footer = new FooterDAL().ViewDetail(id);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // POST: Admin/Footers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FooterID,Content,Status")] Footer footer)
        {
            if (ModelState.IsValid)
            {
                var dao = new FooterDAL();

                var _result = dao.Update(footer);
                if (_result)
                {
                    return RedirectToAction("Index", "Footers");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Footer ko thành công");
                }
            }
            return View(footer);
        }

        // GET: Admin/Footers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var footer = new FooterDAL().ViewDetail(id);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // POST: Admin/Footers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            new FooterDAL().Delete(id);
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

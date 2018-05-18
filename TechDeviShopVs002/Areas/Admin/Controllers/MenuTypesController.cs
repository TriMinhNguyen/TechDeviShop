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
    public class MenuTypesController : BaseController
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/MenuTypes
        public ActionResult Index()
        {
            return View(db.MenuTypes.ToList());
        }

        // GET: Admin/MenuTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var menuType = new MenuTypeDAL().ViewDetail(id);
            if (menuType == null)
            {
                return HttpNotFound();
            }
            return View(menuType);
        }

        // GET: Admin/MenuTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MenuTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuTypeID,Name")] MenuType menuType)
        {
            if (ModelState.IsValid)
            {
                var _dal = new MenuTypeDAL();

                int id = _dal.Insert(menuType);
                if (id > 0)
                {
                    return RedirectToAction("Index", "MenuTypes");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Menu Type ko thành công");
                }
            }

            return View(menuType);
        }

        // GET: Admin/MenuTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var menuType = new MenuTypeDAL().ViewDetail(id);
            if (menuType == null)
            {
                return HttpNotFound();
            }
            return View(menuType);
        }

        // POST: Admin/MenuTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuTypeID,Name")] MenuType menuType)
        {
            if (ModelState.IsValid)
            {
                var _dal = new MenuTypeDAL();

                var _result = _dal.Update(menuType);
                if (_result)
                {
                    return RedirectToAction("Index", "MenuTypes");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Menu Type ko thành công");
                }
            }
            return View(menuType);
        }

        // GET: Admin/MenuTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var menuType = new MenuTypeDAL().ViewDetail(id);
            if (menuType == null)
            {
                return HttpNotFound();
            }
            return View(menuType);
        }

        // POST: Admin/MenuTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new MenuTypeDAL().Delete(id);
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

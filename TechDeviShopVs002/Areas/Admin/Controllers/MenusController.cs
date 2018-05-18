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
    public class MenusController : BaseController
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/Menus
        public ActionResult Index()
        {
            var _menus = db.Menus.Include(m => m.MenuType);
            return View(_menus.ToList());
        }

        // GET: Admin/Menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var menu = new MenuDAL().ViewDetail(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: Admin/Menus/Create
        public ActionResult Create()
        {
            ViewBag.MenuTypeID = new SelectList(db.MenuTypes, "MenuTypeID", "Name");
            return View();
        }

        // POST: Admin/Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuID,Text,Link,DisplayOrder,Target,ParentID,MenuTypeID")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                var _dal = new MenuDAL();

                int id = _dal.Insert(menu);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Menus");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Menu ko thành công");
                }
            }
            ViewBag.MenuTypeID = new SelectList(db.MenuTypes, "MenuTypeID", "Name", menu.MenuTypeID);
            return View(menu);
        }

        // GET: Admin/Menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var menu = new MenuDAL().ViewDetail(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuTypeID = new SelectList(db.MenuTypes, "MenuTypeID", "Name", menu.MenuTypeID);
            return View(menu);
        }

        // POST: Admin/Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuID,Text,Link,DisplayOrder,Target,ParentID,MenuTypeID")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                var _dal = new MenuDAL();

                var _result = _dal.Update(menu);
                if (_result)
                {
                    return RedirectToAction("Index", "Menus");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Menu ko thành công");
                }
            }
            ViewBag.MenuTypeID = new SelectList(db.MenuTypes, "MenuTypeID", "Name", menu.MenuTypeID);
            return View(menu);
        }

        // GET: Admin/Menus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var menu = new MenuDAL().ViewDetail(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Admin/Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new MenuDAL().Delete(id);
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

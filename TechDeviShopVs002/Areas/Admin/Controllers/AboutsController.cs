﻿using System;
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
    public class AboutsController : BaseController
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/Abouts
        public ActionResult Index()
        {
            return View(db.Abouts.ToList());
        }

        // GET: Admin/Abouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var about = new AboutDAL().ViewDetail(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // GET: Admin/Abouts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Abouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AboutID,AboutName,MetaTitle,Description,Image,Detail,MetalKeywords,MetalDescriptions,CreateDate,CreateUser,ModifiedDate,ModifiedUser,IsActive")] About about)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new AboutDAL();

                about.CreateUser = UserSession.UserID;

                int id = _dal.Insert(about);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Abouts");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm about ko thành công");
                }
            }

            return View(about);
        }

        // GET: Admin/Abouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var about = new AboutDAL().ViewDetail(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: Admin/Abouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AboutID,AboutName,MetaTitle,Description,Image,Detail,MetalKeywords,MetalDescriptions,CreateDate,CreateUser,ModifiedDate,ModifiedUser,IsActive")] About about)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new AboutDAL();

                about.ModifiedUser = UserSession.UserID;

                var _result = _dal.Update(about);
                if (_result)
                {
                    return RedirectToAction("Index", "Abouts");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật about ko thành công");
                }
            }
            return View(about);
        }

        // GET: Admin/Abouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var about = new AboutDAL().ViewDetail(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: Admin/Abouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new AboutDAL().Delete(id);
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

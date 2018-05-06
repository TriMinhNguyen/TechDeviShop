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
    public class SystemConfigsController : Controller
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/SystemConfigs
        public ActionResult Index()
        {
            return View(db.SystemConfigs.ToList());
        }

        // GET: Admin/SystemConfigs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var systemConfig = new SystemConfigDAL().ViewDetail(id);
            if (systemConfig == null)
            {
                return HttpNotFound();
            }
            return View(systemConfig);
        }

        // GET: Admin/SystemConfigs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SystemConfigs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SystemConfigID,Name,Type,Value,IsActive")] SystemConfig systemConfig)
        {
            if (ModelState.IsValid)
            {
                var _dal = new SystemConfigDAL();

                int id = _dal.Insert(systemConfig);
                if (id > 0)
                {
                    return RedirectToAction("Index", "SystemConfigs");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Thiết lập hệ thống ko thành công");
                }
            }

            return View(systemConfig);
        }

        // GET: Admin/SystemConfigs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var systemConfig = new SystemConfigDAL().ViewDetail(id);
            if (systemConfig == null)
            {
                return HttpNotFound();
            }
            return View(systemConfig);
        }

        // POST: Admin/SystemConfigs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SystemConfigID,Name,Type,Value,IsActive")] SystemConfig systemConfig)
        {
            if (ModelState.IsValid)
            {
                var _dal = new SystemConfigDAL();

                var _result = _dal.Update(systemConfig);
                if (_result)
                {
                    return RedirectToAction("Index", "SystemConfigs");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thiết lập hệ thống ko thành công");
                }
            }
            return View(systemConfig);
        }

        // GET: Admin/SystemConfigs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var systemConfig = new SystemConfigDAL().ViewDetail(id);
            if (systemConfig == null)
            {
                return HttpNotFound();
            }
            return View(systemConfig);
        }

        // POST: Admin/SystemConfigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new SystemConfigDAL().Delete(id);
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

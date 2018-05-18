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
    public class ShippersController : BaseController
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/Shippers
        public ActionResult Index()
        {
            return View(db.Shippers.ToList());
        }

        // GET: Admin/Shippers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shipper = new ShipperDAL().ViewDetail(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            return View(shipper);
        }

        // GET: Admin/Shippers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Shippers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipperID,Name,Email,Phone,Fax,Address,CreateDate,CreateBy,ModifiedDate,ModifiedBy,IsActive")] Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                var _dal = new ShipperDAL();

                int id = _dal.Insert(shipper);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Shippers");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm shipper ko thành công");
                }
            }

            return View(shipper);
        }

        // GET: Admin/Shippers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shipper = new ShipperDAL().ViewDetail(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            return View(shipper);
        }

        // POST: Admin/Shippers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipperID,Name,Email,Phone,Fax,Address,CreateDate,CreateBy,ModifiedDate,ModifiedBy,IsActive")] Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                var _dal = new ShipperDAL();
                var _result = _dal.Update(shipper);
                if (_result)
                {
                    return RedirectToAction("Index", "Shippers");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật shipper ko thành công");
                }
            }
            return View(shipper);
        }

        // GET: Admin/Shippers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shipper = new ShipperDAL().ViewDetail(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            return View(shipper);
        }

        // POST: Admin/Shippers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new ShipperDAL().Delete(id);
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

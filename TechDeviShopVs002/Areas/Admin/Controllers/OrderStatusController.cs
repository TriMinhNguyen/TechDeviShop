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
    public class OrderStatusController : Controller
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/OrderStatus
        public ActionResult Index()
        {
            return View(db.OrderStatus.ToList());
        }

        // GET: Admin/OrderStatus/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderStatu = new OrderStatusDAL().ViewDetail(id);
            if (orderStatu == null)
            {
                return HttpNotFound();
            }
            return View(orderStatu);
        }

        // GET: Admin/OrderStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/OrderStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderStatusID,OrderStatusName,Description,DisplayOrder,CreateDate,CreateBy,ModifiedDate,ModifiedBy,IsActive")] OrderStatu orderStatu)
        {
            if (ModelState.IsValid)
            {
                var _dal = new OrderStatusDAL();

                int id = _dal.Insert(orderStatu);
                if (id > 0)
                {
                    return RedirectToAction("Index", "OrderStatus");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm trạng thái hóa đơn ko thành công");
                }
            }

            return View(orderStatu);
        }

        // GET: Admin/OrderStatus/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderStatu = new OrderStatusDAL().ViewDetail(id);
            if (orderStatu == null)
            {
                return HttpNotFound();
            }
            return View(orderStatu);
        }

        // POST: Admin/OrderStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderStatusID,OrderStatusName,Description,DisplayOrder,CreateDate,CreateBy,ModifiedDate,ModifiedBy,IsActive")] OrderStatu orderStatu)
        {
            if (ModelState.IsValid)
            {
                var _dal = new OrderStatusDAL();
                var _result = _dal.Update(orderStatu);
                if (_result)
                {
                    return RedirectToAction("Index", "OrderStatus");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật trạng thái hóa đơn ko thành công");
                }
            }
            return View(orderStatu);
        }

        // GET: Admin/OrderStatus/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderStatu = new OrderStatusDAL().ViewDetail(id);
            if (orderStatu == null)
            {
                return HttpNotFound();
            }
            return View(orderStatu);
        }

        // POST: Admin/OrderStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            new OrderStatusDAL().Delete(id);
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

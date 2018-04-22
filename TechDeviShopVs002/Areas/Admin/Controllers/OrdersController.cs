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
    public class OrdersController : Controller
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.ShippingMethod);
            return View(orders.ToList());
        }

        // GET: Admin/Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = new OrderDAL().ViewDetail(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Admin/Orders/Create
        public ActionResult Create()
        {
            ViewBag.ShippingMethodID = new SelectList(db.ShippingMethod, "ShippingMethodID", "Title");
            return View();
        }

        // POST: Admin/Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,CustomerID,ShipperID,ShippingMethodID,ShippingCost,SubTotal,TotalPrice,CusName,CusPhone,CusEmail,Company,City,District,Address,ShippingPostalCode,OrtherNote,CreateDate,ShippedDate,TransactionID,TrackingID")] Orders order)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDAL();

                int id = dao.Insert(order);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Orders");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Hoa don ko thành công");
                }
            }

            ViewBag.ShippingMethodID = new SelectList(db.ShippingMethod, "ShippingMethodID", "Title", order.ShippingMethodID);
            return View(order);
        }

        // GET: Admin/Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = new OrderDAL().ViewDetail(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShippingMethodID = new SelectList(db.ShippingMethod, "ShippingMethodID", "Title", order.ShippingMethodID);
            return View(order);
        }

        // POST: Admin/Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,CustomerID,ShipperID,ShippingMethodID,ShippingCost,SubTotal,TotalPrice,CusName,CusPhone,CusEmail,Company,City,District,Address,ShippingPostalCode,OrtherNote,CreateDate,ShippedDate,TransactionID,TrackingID")] Orders order)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDAL();

                var _result = dao.Update(order);
                if (_result)
                {
                    return RedirectToAction("Index", "Orders");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Hoa don ko thành công");
                }
            }
            ViewBag.ShippingMethodID = new SelectList(db.ShippingMethod, "ShippingMethodID", "Title", order.ShippingMethodID);
            return View(order);
        }

        // GET: Admin/Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = new OrderDAL().ViewDetail(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Admin/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new OrderDAL().Delete(id);
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

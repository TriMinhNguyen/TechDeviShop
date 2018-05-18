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
    public class OrdersController : BaseController
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.OrderStatus).Include(o => o.Shipper).Include(o => o.ShippingMethod).Include(o => o.User);
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
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            ViewBag.OrderStatusID = new SelectList(db.OrderStatus, "OrderStatusID", "OrderStatusName");
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "Name");
            ViewBag.ShippingMethodID = new SelectList(db.ShippingMethods, "ShippingMethodID", "Title");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: Admin/Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,UserID,CustomerID,ShipperID,ShippingMethodID,OrderStatusID,ShippingCost,CusName,CusPhone,CusEmail,Company,City,District,Address,ShippingPostalCode,OrtherNote,OrderDate,ShippedDate,RequiredDate,CreateDate,CreateBy,IsActive")] Order order)
        {
            if (ModelState.IsValid)
            {
                var _dal = new OrderDAL();

                int id = _dal.Insert(order);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Orders");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Hóa đơn ko thành công");
                }
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", order.CustomerID);
            ViewBag.OrderStatusID = new SelectList(db.OrderStatus, "OrderStatusID", "OrderStatusName", order.OrderStatusID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "Name", order.ShipperID);
            ViewBag.ShippingMethodID = new SelectList(db.ShippingMethods, "ShippingMethodID", "Title", order.ShippingMethodID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", order.UserID);
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
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", order.CustomerID);
            ViewBag.OrderStatusID = new SelectList(db.OrderStatus, "OrderStatusID", "OrderStatusName", order.OrderStatusID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "Name", order.ShipperID);
            ViewBag.ShippingMethodID = new SelectList(db.ShippingMethods, "ShippingMethodID", "Title", order.ShippingMethodID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", order.UserID);
            return View(order);
        }

        // POST: Admin/Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,UserID,CustomerID,ShipperID,ShippingMethodID,OrderStatusID,ShippingCost,CusName,CusPhone,CusEmail,Company,City,District,Address,ShippingPostalCode,OrtherNote,OrderDate,ShippedDate,RequiredDate,CreateDate,CreateBy,IsActive")] Order order)
        {
            if (ModelState.IsValid)
            {
                var _dal = new OrderDAL();

                var _result = _dal.Update(order);
                if (_result)
                {
                    return RedirectToAction("Index", "Orders");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật hóa đơn ko thành công");
                }
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", order.CustomerID);
            ViewBag.OrderStatusID = new SelectList(db.OrderStatus, "OrderStatusID", "OrderStatusName", order.OrderStatusID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "Name", order.ShipperID);
            ViewBag.ShippingMethodID = new SelectList(db.ShippingMethods, "ShippingMethodID", "Title", order.ShippingMethodID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", order.UserID);
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

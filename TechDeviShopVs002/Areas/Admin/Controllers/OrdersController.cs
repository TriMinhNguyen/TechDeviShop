using PagedList;
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
        public ViewResult Index(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var orders = db.Orders.Include(o => o.Customer).Include(o => o.OrderStatus).Include(o => o.Shipper).Include(o => o.ShippingMethod);
            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s => s.Customer.CustomerName.Contains(searchString)
                                       || s.ShippingMethod.Title.Contains(searchString)
                                       || s.OrderStatus.OrderStatusName.Contains(searchString));
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(orders.OrderByDescending(u => u.CreateDate).ToPagedList(pageNumber, pageSize));
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
            return View();
        }

        // POST: Admin/Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,UserID,CustomerID,ShipperID,ShippingMethodID,OrderStatusID,ShippingCost,CusName,CusPhone,CusEmail,Company,City,District,Address,ShippingPostalCode,OrtherNote,OrderDate,ShippedDate,RequiredDate,CreateDate,CreateUser,IsActive")] Order order)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new OrderDAL();

                order.CreateUser = UserSession.UserID;
                order.OrderDate = DateTime.Now;

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
            return View(order);
        }

        // POST: Admin/Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,UserID,CustomerID,ShipperID,ShippingMethodID,OrderStatusID,ShippingCost,CusName,CusPhone,CusEmail,Company,City,District,Address,ShippingPostalCode,OrtherNote,OrderDate,ShippedDate,RequiredDate,CreateDate,CreateUser,IsActive")] Order order)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new OrderDAL();

                order.ModifiedUser = UserSession.UserID;

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


        public ActionResult CompleteOrder(int id)
        {
            var order = new OrderDAL().ViewDetail(id);
            order.OrderStatusID = 4;

            var _dal = new OrderDAL();

            var listOD = new OrderDetailsDAL().ListByOrderID(id).ToList();

            foreach (var item in listOD)
            {
                //Edit Product Quantity
                var product = new ProductDAL().ViewDetail(item.ProductID);
                if (product.Quantity > 1)
                {
                    product.Quantity = product.Quantity - (int)item.Quantity;
                }
                var productResult = new ProductDAL().Update(product);
            }

            var _result = _dal.Update(order);

            if (_result)
            {
                return RedirectToAction("Index", "Orders");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật trạng thái không thành công ko thành công");
            }

            return View(order);
        }

        public ActionResult CancelOrder(int id)
        {
            var order = new OrderDAL().ViewDetail(id);
            order.OrderStatusID = 5;

            var _dal = new OrderDAL();
            var _result = _dal.Update(order);

            if (_result)
            {
                return RedirectToAction("Index", "Orders");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật trạng thái không thành công ko thành công");
            }

            return View(order);
        }
        
    }
}

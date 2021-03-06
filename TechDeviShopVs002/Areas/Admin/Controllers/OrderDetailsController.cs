﻿using PagedList;
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
    public class OrderDetailsController : BaseController
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/OrderDetails
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

            var orderDetail = db.OrderDetails.Include(o => o.Product);
            if (!String.IsNullOrEmpty(searchString))
            {
                orderDetail = orderDetail.Where(s => s.Product.ProductName.Contains(searchString));
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(orderDetail.OrderBy(u => u.ProductName).ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/OrderDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderDetail = new OrderDetailsDAL().ViewDetail(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // GET: Admin/OrderDetails/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            //ViewBag.ProductName = new SelectList(db.Products, "ProductName", "ProductName");
            //ViewBag.ProductCode = new SelectList(db.Products, "ProductCode", "ProductCode");
            //ViewBag.UnitPrice = new SelectList(db.Products, "UnitPrice", "Price");
            //ViewBag.PromotionPrice = new SelectList(db.Products, "PromotionPrice", "PromotionPrice");
            return View();
        }

        // POST: Admin/OrderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderDetailID,OrderID,ProductID,ProductName,ProductCode,UnitPrice,Quantity,PromotionPrice,CreateDate,CreateUser,ModifiedDate,ModifiedUser,IsActive")] OrderDetail orderDetail)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new OrderDetailsDAL();

                orderDetail.CreateUser = UserSession.UserID;
                var pd = new ProductDAL().ViewDetail(orderDetail.ProductID);
                orderDetail.ProductName = pd.ProductName;
                orderDetail.ProductCode = pd.ProductCode;
                orderDetail.UnitPrice = pd.Price;
                orderDetail.PromotionPrice = pd.PromotionPrice;

                int id = _dal.Insert(orderDetail);
                if (id > 0)
                {
                    return RedirectToAction("Index", "OrderDetails");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Chi tiết hóa đơn ko thành công");
                }
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", orderDetail.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", orderDetail.ProductID);
            //ViewBag.ProductName = new SelectList(db.Products, "ProductName", "ProductName", orderDetail.ProductName);
            //ViewBag.ProductCode = new SelectList(db.Products, "ProductCode", "ProductCode", orderDetail.ProductCode);
            //ViewBag.UnitPrice = new SelectList(db.Products, "UnitPrice", "Price", orderDetail.UnitPrice);
            //ViewBag.PromotionPrice = new SelectList(db.Products, "PromotionPrice", "PromotionPrice", orderDetail.PromotionPrice);
            return View(orderDetail);
        }

        // GET: Admin/OrderDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderDetail = new OrderDetailsDAL().ViewDetail(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", orderDetail.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", orderDetail.ProductID);
            //ViewBag.ProductName = new SelectList(db.Products, "ProductName", "ProductName", orderDetail.ProductName);
            //ViewBag.ProductCode = new SelectList(db.Products, "ProductCode", "ProductCode", orderDetail.ProductCode);
            //ViewBag.UnitPrice = new SelectList(db.Products, "UnitPrice", "Price", orderDetail.UnitPrice);
            //ViewBag.PromotionPrice = new SelectList(db.Products, "PromotionPrice", "PromotionPrice", orderDetail.PromotionPrice);
            return View(orderDetail);
        }

        // POST: Admin/OrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderDetailID,OrderID,ProductID,ProductName,ProductCode,UnitPrice,Quantity,PromotionPrice,CreateDate,CreateUser,ModifiedDate,ModifiedUser,IsActive")] OrderDetail orderDetail)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new OrderDetailsDAL();

                orderDetail.ModifiedUser = UserSession.UserID;
                var pd = new ProductDAL().ViewDetail(orderDetail.ProductID);
                orderDetail.ProductName = pd.ProductName;
                orderDetail.ProductCode = pd.ProductCode;
                orderDetail.UnitPrice = pd.Price;
                orderDetail.PromotionPrice = pd.PromotionPrice;

                var _result = _dal.Update(orderDetail);
                if (_result)
                {
                    return RedirectToAction("Index", "orderDetails");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật chi tiết hóa đơn ko thành công");
                }
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", orderDetail.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", orderDetail.ProductID);
            //ViewBag.ProductName = new SelectList(db.Products, "ProductName", "ProductName", orderDetail.ProductName);
            //ViewBag.ProductCode = new SelectList(db.Products, "ProductCode", "ProductCode", orderDetail.ProductCode);
            //ViewBag.UnitPrice = new SelectList(db.Products, "UnitPrice", "Price", orderDetail.UnitPrice);
            //ViewBag.PromotionPrice = new SelectList(db.Products, "PromotionPrice", "PromotionPrice", orderDetail.PromotionPrice);
            return View(orderDetail);
        }

        // GET: Admin/OrderDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderDetail = new OrderDetailsDAL().ViewDetail(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: Admin/OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new OrderDetailsDAL().Delete(id);
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


        public ViewResult ODofCustomer(int cID, string currentFilter, string searchString, int? page)
        {
            ViewBag.CustInfo = new CustomerDAL().ViewDetail(cID);

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var orderDetail = db.OrderDetails.Where(o=>o.Order.CustomerID == cID).Include(o => o.Product);

            if (!String.IsNullOrEmpty(searchString))
            {
                orderDetail = orderDetail.Where(s => s.Product.ProductName.Contains(searchString));
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(orderDetail.OrderBy(u => u.ProductName).ToPagedList(pageNumber, pageSize));
        }

        public ViewResult ODofOrder(int oID)
        {
            var model = new OrderDetailsDAL().ListByOrderID(oID);

            ViewBag.ODinfo = new OrderDAL().ViewDetail(oID);
            return View(model);
        }
    }
}

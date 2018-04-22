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
    public class ShoppingCartsController : Controller
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/ShoppingCarts
        public ActionResult Index()
        {
            var shoppingCarts = db.ShoppingCart.Include(s => s.ShippingMethod);
            return View(shoppingCarts.ToList());
        }

        // GET: Admin/ShoppingCarts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shoppingCart = new ShoppingCartDAL().ViewDetail(id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCart);
        }

        // GET: Admin/ShoppingCarts/Create
        public ActionResult Create()
        {
            ViewBag.ShippingMethodID = new SelectList(db.ShippingMethod, "ShippingMethodID", "Title");
            return View();
        }

        // POST: Admin/ShoppingCarts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoppingCartID,ShippingMethodID,ShippingCost,SubTotal,TotalPrice,CreateDate")] ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                var _shoppingCart = new ShoppingCartDAL();

                int id = _shoppingCart.Insert(shoppingCart);
                if (id > 0)
                {
                    return RedirectToAction("Index", "ShoppingCarts");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm giỏ hàng ko thành công");
                }
            }

            ViewBag.ShippingMethodID = new SelectList(db.ShippingMethod, "ShippingMethodID", "Title", shoppingCart.ShippingMethodID);
            return View(shoppingCart);
        }

        // GET: Admin/ShoppingCarts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shoppingCart = new ShoppingCartDAL().ViewDetail(id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShippingMethodID = new SelectList(db.ShippingMethod, "ShippingMethodID", "Title", shoppingCart.ShippingMethodID);
            return View(shoppingCart);
        }

        // POST: Admin/ShoppingCarts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoppingCartID,ShippingMethodID,ShippingCost,SubTotal,TotalPrice,CreateDate")] ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                var dao = new ShoppingCartDAL();
                var _result = dao.Update(shoppingCart);
                if (_result)
                {
                    return RedirectToAction("Index", "ShoppingCarts");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật giỏ hàng ko thành công");
                }
            }
            ViewBag.ShippingMethodID = new SelectList(db.ShippingMethod, "ShippingMethodID", "Title", shoppingCart.ShippingMethodID);
            return View(shoppingCart);
        }

        // GET: Admin/ShoppingCarts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shoppingCart = new ShoppingCartDAL().ViewDetail(id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCart);
        }

        // POST: Admin/ShoppingCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new ShoppingCartDAL().Delete(id);
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

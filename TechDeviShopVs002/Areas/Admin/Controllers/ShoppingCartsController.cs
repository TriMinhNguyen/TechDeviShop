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
    public class ShoppingCartsController : BaseController
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/ShoppingCarts
        public ActionResult Index()
        {
            return View(db.ShoppingCarts.ToList());
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
            return View();
        }

        // POST: Admin/ShoppingCarts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoppingCartID,ShoppingDate,ExpireDate,Note,CreateDate,CreateUser,ModifiedDate,ModifiedUser,IsActive")] ShoppingCart shoppingCart)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new ShoppingCartDAL();

                shoppingCart.CreateUser = UserSession.UserID;

                int id = _dal.Insert(shoppingCart);
                if (id > 0)
                {
                    return RedirectToAction("Index", "ShoppingCarts");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm giỏ hàng ko thành công");
                }
            }

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
            return View(shoppingCart);
        }

        // POST: Admin/ShoppingCarts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoppingCartID,ShoppingDate,ExpireDate,Note,CreateDate,CreateUser,ModifiedDate,ModifiedUser,IsActive")] ShoppingCart shoppingCart)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new ShoppingCartDAL();

                shoppingCart.ModifiedUser = UserSession.UserID;

                var _result = _dal.Update(shoppingCart);
                if (_result)
                {
                    return RedirectToAction("Index", "ShoppingCarts");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật giỏ hàng ko thành công");
                }
            }
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

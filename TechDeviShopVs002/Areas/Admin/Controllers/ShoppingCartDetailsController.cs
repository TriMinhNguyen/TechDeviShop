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
    public class ShoppingCartDetailsController : Controller
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/ShoppingCartDetails
        public ActionResult Index()
        {
            var shoppingCartDetails = db.ShoppingCartDetails.Include(s => s.ShoppingCart);
            return View(shoppingCartDetails.ToList());
        }

        // GET: Admin/ShoppingCartDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shoppingCartDetail = new ShoppingCartDetailDAL().ViewDetail(id);
            if (shoppingCartDetail == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCartDetail);
        }

        // GET: Admin/ShoppingCartDetails/Create
        public ActionResult Create()
        {
            ViewBag.ShoppingCartID = new SelectList(db.ShoppingCart, "ShoppingCartID", "ShoppingCartID");
            return View();
        }

        // POST: Admin/ShoppingCartDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoppingCartDetailID,ShoppingCartID,ProductID,Title,UnitPrice,Quantity,CreateDate")] ShoppingCartDetails shoppingCartDetail)
        {
            if (ModelState.IsValid)
            {
                var _SCD = new ShoppingCartDetailDAL();

                int id = _SCD.Insert(shoppingCartDetail);
                if (id > 0)
                {
                    return RedirectToAction("Index", "ShoppingCartDetails");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm chi tiết giỏ hàng ko thành công");
                }
            }

            ViewBag.ShoppingCartID = new SelectList(db.ShoppingCart, "ShoppingCartID", "ShoppingCartID", shoppingCartDetail.ShoppingCartID);
            return View(shoppingCartDetail);
        }

        // GET: Admin/ShoppingCartDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shoppingCartDetail = new ShoppingCartDetailDAL().ViewDetail(id);
            if (shoppingCartDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShoppingCartID = new SelectList(db.ShoppingCart, "ShoppingCartID", "ShoppingCartID", shoppingCartDetail.ShoppingCartID);
            return View(shoppingCartDetail);
        }

        // POST: Admin/ShoppingCartDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoppingCartDetailID,ShoppingCartID,ProductID,Title,UnitPrice,Quantity,CreateDate")] ShoppingCartDetails shoppingCartDetail)
        {
            if (ModelState.IsValid)
            {
                var dao = new ShoppingCartDetailDAL();
                var _result = dao.Update(shoppingCartDetail);
                if (_result)
                {
                    return RedirectToAction("Index", "ShoppingCartDetails");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật chi tiết giỏ hàng ko thành công");
                }
            }
            ViewBag.ShoppingCartID = new SelectList(db.ShoppingCart, "ShoppingCartID", "ShoppingCartID", shoppingCartDetail.ShoppingCartID);
            return View(shoppingCartDetail);
        }

        // GET: Admin/ShoppingCartDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shoppingCartDetail = new ShoppingCartDetailDAL().ViewDetail(id);
            if (shoppingCartDetail == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCartDetail);
        }

        // POST: Admin/ShoppingCartDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new ShoppingCartDetailDAL().Delete(id);
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

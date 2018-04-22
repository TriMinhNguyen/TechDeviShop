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
    public class ShippingMethodsController : Controller
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/ShippingMethods
        public ActionResult Index()
        {
            return View(db.ShippingMethod.ToList());
        }

        // GET: Admin/ShippingMethods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shippingMethod = new ShippingMethodDAL().ViewDetail(id);
            if (shippingMethod == null)
            {
                return HttpNotFound();
            }
            return View(shippingMethod);
        }

        // GET: Admin/ShippingMethods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ShippingMethods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShippingMethodID,Title,Price,CreateDate")] ShippingMethod shippingMethod)
        {
            if (ModelState.IsValid)
            {
                var _shipM = new ShippingMethodDAL();

                int id = _shipM.Insert(shippingMethod);
                if (id > 0)
                {
                    return RedirectToAction("Index", "ShippingMethods");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm phương thức vận chuyển ko thành công");
                }
            }

            return View(shippingMethod);
        }

        // GET: Admin/ShippingMethods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shippingMethod = new ShippingMethodDAL().ViewDetail(id);
            if (shippingMethod == null)
            {
                return HttpNotFound();
            }
            return View(shippingMethod);
        }

        // POST: Admin/ShippingMethods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShippingMethodID,Title,Price,CreateDate")] ShippingMethod shippingMethod)
        {
            if (ModelState.IsValid)
            {
                var dao = new ShippingMethodDAL();
                var _result = dao.Update(shippingMethod);
                if (_result)
                {
                    return RedirectToAction("Index", "ShippingMethods");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật phương thức vận chuyển ko thành công");
                }
            }
            return View(shippingMethod);
        }

        // GET: Admin/ShippingMethods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shippingMethod = new ShippingMethodDAL().ViewDetail(id);
            if (shippingMethod == null)
            {
                return HttpNotFound();
            }
            return View(shippingMethod);
        }

        // POST: Admin/ShippingMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new CategoryDAL().Delete(id);
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

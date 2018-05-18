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
    public class PaymentMethodsController : BaseController
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/PaymentMethods
        public ActionResult Index()
        {
            return View(db.PaymentMethods.ToList());
        }

        // GET: Admin/PaymentMethods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var paymentMethod = new PaymentMethodDAL().ViewDetail(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(paymentMethod);
        }

        // GET: Admin/PaymentMethods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PaymentMethods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentMethodID,Name,Note,CreateDate,CreateBy,ModifiedDate,ModifiedBy,IsActive")] PaymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                var _dal = new PaymentMethodDAL();

                int id = _dal.Insert(paymentMethod);
                if (id > 0)
                {
                    return RedirectToAction("Index", "PaymentMethods");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm phương thức thanh toán ko thành công");
                }
            }

            return View(paymentMethod);
        }

        // GET: Admin/PaymentMethods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var paymentMethod = new PaymentMethodDAL().ViewDetail(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(paymentMethod);
        }

        // POST: Admin/PaymentMethods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentMethodID,Name,Note,CreateDate,CreateBy,ModifiedDate,ModifiedBy,IsActive")] PaymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                var _dal = new PaymentMethodDAL();

                var _result = _dal.Update(paymentMethod);
                if (_result)
                {
                    return RedirectToAction("Index", "PaymentMethods");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật phương thức thanh toán ko thành công");
                }
            }
            return View(paymentMethod);
        }

        // GET: Admin/PaymentMethods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var paymentMethod = new PaymentMethodDAL().ViewDetail(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(paymentMethod);
        }

        // POST: Admin/PaymentMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new PaymentMethodDAL().Delete(id);
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

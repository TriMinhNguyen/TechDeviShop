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
    public class PaymentsController : Controller
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/Payments
        public ActionResult Index()
        {
            var _payment = db.Payments.Include(o => o.PaymentMethod).Include(o => o.PaymentStatus);
            return View(_payment.ToList());
        }

        // GET: Admin/Payments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var payment = new PaymentDAL().ViewDetail(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Admin/Payments/Create
        public ActionResult Create()
        {
            ViewBag.PaymentMethodID = new SelectList(db.PaymentMethods, "PaymentMethodID", "Name");
            ViewBag.PaymentStatusID = new SelectList(db.PaymentStatus, "PaymentStatusID", "Name");
            return View();
        }

        // POST: Admin/Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentID,OrderID,PaymentMethodID,PaymentStatusID,PaymentDate,TotalPrice,Note,CreateDate,CreateBy,ModifiedDate,ModifiedBy,TransactionID,TrackingID,IsActive")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                var _dal = new PaymentDAL();

                int id = _dal.Insert(payment);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Payments");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thanh toán ko thành công");
                }
            }
            ViewBag.PaymentMethodID = new SelectList(db.PaymentMethods, "PaymentMethodID", "Name", payment.PaymentMethodID);
            ViewBag.PaymentStatusID = new SelectList(db.PaymentStatus, "PaymentStatusID", "Name", payment.PaymentStatusID);
            return View(payment);
        }

        // GET: Admin/Payments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var payment = new PaymentDAL().ViewDetail(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaymentMethodID = new SelectList(db.PaymentMethods, "PaymentMethodID", "Name", payment.PaymentMethodID);
            ViewBag.PaymentStatusID = new SelectList(db.PaymentStatus, "PaymentStatusID", "Name", payment.PaymentStatusID);
            return View(payment);
        }

        // POST: Admin/Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentID,OrderID,PaymentMethodID,PaymentStatusID,PaymentDate,TotalPrice,Note,CreateDate,CreateBy,ModifiedDate,ModifiedBy,TransactionID,TrackingID,IsActive")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                var _dal = new PaymentDAL();

                var _result = _dal.Update(payment);
                if (_result)
                {
                    return RedirectToAction("Index", "Payments");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thanh toán ko thành công");
                }
            }
            ViewBag.PaymentMethodID = new SelectList(db.PaymentMethods, "PaymentMethodID", "Name", payment.PaymentMethodID);
            ViewBag.PaymentStatusID = new SelectList(db.PaymentStatus, "PaymentStatusID", "Name", payment.PaymentStatusID);
            return View(payment);
        }

        // GET: Admin/Payments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var payment = new PaymentDAL().ViewDetail(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Admin/Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new PaymentDAL().Delete(id);
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

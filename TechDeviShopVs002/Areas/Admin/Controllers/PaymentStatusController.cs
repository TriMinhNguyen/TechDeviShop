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
    public class PaymentStatusController : Controller
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/PaymentStatus
        public ActionResult Index()
        {
            return View(db.PaymentStatus.ToList());
        }

        // GET: Admin/PaymentStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var paymentStatu = new PaymentStatusDAL().ViewDetail(id);
            if (paymentStatu == null)
            {
                return HttpNotFound();
            }
            return View(paymentStatu);
        }

        // GET: Admin/PaymentStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PaymentStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentStatusID,Name,Note,CreateDate,CreateBy,ModifiedDate,ModifiedBy,IsActive")] PaymentStatu paymentStatu)
        {
            if (ModelState.IsValid)
            {
                var _dal = new PaymentStatusDAL();

                int id = _dal.Insert(paymentStatu);
                if (id > 0)
                {
                    return RedirectToAction("Index", "PaymentStatus");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm trạng thái thanh toán ko thành công");
                }
            }

            return View(paymentStatu);
        }

        // GET: Admin/PaymentStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var paymentStatu = new PaymentStatusDAL().ViewDetail(id);
            if (paymentStatu == null)
            {
                return HttpNotFound();
            }
            return View(paymentStatu);
        }

        // POST: Admin/PaymentStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentStatusID,Name,Note,CreateDate,CreateBy,ModifiedDate,ModifiedBy,IsActive")] PaymentStatu paymentStatu)
        {
            if (ModelState.IsValid)
            {
                var _dal = new PaymentStatusDAL();

                var _result = _dal.Update(paymentStatu);
                if (_result)
                {
                    return RedirectToAction("Index", "PaymentStatus");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật trạng thái thanh toán ko thành công");
                }
            }
            return View(paymentStatu);
        }

        // GET: Admin/PaymentStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var paymentStatu = new PaymentStatusDAL().ViewDetail(id);
            if (paymentStatu == null)
            {
                return HttpNotFound();
            }
            return View(paymentStatu);
        }

        // POST: Admin/PaymentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new PaymentStatusDAL().Delete(id);
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

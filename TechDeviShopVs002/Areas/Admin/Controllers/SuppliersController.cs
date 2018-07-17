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
    public class SuppliersController : BaseController
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/Suppliers
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

            var supplier = from s in db.Suppliers
                       select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                supplier = supplier.Where(x => x.SupplierName.Contains(searchString)
                                       || x.PhoneNumber.Contains(searchString));
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(supplier.OrderBy(u => u.SupplierName).ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Suppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var supplier = new SupplierDAL().ViewDetail(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Admin/Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierID,SupplierName,MetaTitle,EmailSupport,PhoneNumber,Detail,CreateDate,CreateUser,ModifiedDate,ModifiedUser,IsActive")] Supplier supplier)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new SupplierDAL();

                supplier.CreateUser = UserSession.UserID;

                int id = _dal.Insert(supplier);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Suppliers");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Nhà cung cấp ko thành công");
                }
            }

            return View(supplier);
        }

        // GET: Admin/Suppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var supplier = new SupplierDAL().ViewDetail(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Admin/Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierID,SupplierName,MetaTitle,EmailSupport,PhoneNumber,Detail,CreateDate,CreateUser,ModifiedDate,ModifiedUser,IsActive")] Supplier supplier)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new SupplierDAL();

                supplier.ModifiedUser = UserSession.UserID;

                var _result = _dal.Update(supplier);
                if (_result)
                {
                    return RedirectToAction("Index", "Suppliers");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Nhà cung cấp ko thành công");
                }
            }
            return View(supplier);
        }

        // GET: Admin/Suppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var supplier = new SupplierDAL().ViewDetail(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Admin/Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //new SupplierDAL().Delete(id);

            var supplier = new SupplierDAL().ViewDetail(id);
            supplier.IsActive = false;
            var _dal = new SupplierDAL();
            var _result = _dal.Update(supplier);

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

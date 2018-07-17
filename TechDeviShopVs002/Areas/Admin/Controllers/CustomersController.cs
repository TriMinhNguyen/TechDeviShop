using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechDeviShopVs002.Common;
using TechDeviShopVs002.DAL;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.Areas.Admin.Controllers
{
    public class CustomersController : BaseController
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/Customers
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

            var cust = from s in db.Customers
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                cust = cust.Where(x => x.CustomerName.Contains(searchString)
                                       || x.CustomerEmail.Contains(searchString)
                                       || x.CustomerPhone.Contains(searchString));
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(cust.OrderBy(u => u.CustomerName).ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = new CustomerDAL().ViewDetail(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Admin/Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,CustomerEmail,Password,CustomerName,Avatar,CustomerGender,CustomerBirthday,CustomerPhone,CustomerAddress,CustomerCity,CustomerDistrict,PostCost,OrtherDetail,IsActive")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var _dal = new CustomerDAL();

                var encryptedMd5Pas = Encryptor.MD5Hash(customer.Password);
                customer.Password = encryptedMd5Pas;

                int id = _dal.Insert(customer);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Customers");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm khách hàng ko thành công");
                }
            }

            return View(customer);
        }

        // GET: Admin/Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = new CustomerDAL().ViewDetail(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Admin/Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CustomerEmail,Password,CustomerName,Avatar,CustomerGender,CustomerBirthday,CustomerPhone,CustomerAddress,CustomerCity,CustomerDistrict,PostCost,OrtherDetail,IsActive")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var _dal = new CustomerDAL();

                if (!string.IsNullOrEmpty(customer.Password))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(customer.Password);
                    customer.Password = encryptedMd5Pas;
                }

                var _result = _dal.Update(customer);
                if (_result)
                {
                    return RedirectToAction("Index", "Customers");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật khách hàng ko thành công");
                }
            }
            return View(customer);
        }

        // GET: Admin/Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = new CustomerDAL().ViewDetail(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Admin/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //new CustomerDAL().Delete(id);

            var customer = new CustomerDAL().ViewDetail(id);
            customer.IsActive = false;
            var _dal = new CustomerDAL();
            var _result = _dal.Update(customer);

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

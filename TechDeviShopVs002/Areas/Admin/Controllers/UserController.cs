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
    public class UserController : Controller
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/User
        public ActionResult Index()
        {
            var users = db.User.Include(u => u.Role);
            return View(users.ToList());
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = new UserDAL().ViewDetail(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Role, "RoleID", "RoleName");
            return View();
        }

        // POST: Admin/User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserName,Password,Name,Gender,Birthday,Address,Email,Phone,CreateDate,ModifiedDate,RoleID,Status")] User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAL();

                var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMd5Pas;

                int id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user thành công");
                }
            }

            ViewBag.RoleID = new SelectList(db.Role, "RoleID", "RoleName", user.RoleID);
            return View(user);
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = new UserDAL().ViewDetail(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Role, "RoleID", "RoleName", user.RoleID);
            return View(user);
        }

        // POST: Admin/User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName,Password,Name,Gender,Birthday,Address,Email,Phone,CreateDate,ModifiedDate,RoleID,Status")] User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAL();
                //if(!string.IsNullOrEmpty(user.Password))
                //{
                //    var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                //    user.Password = encryptedMd5Pas;
                //}

                var _result = dao.Update(user);
                if (_result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user thành công");
                }
            }
            ViewBag.RoleID = new SelectList(db.Role, "RoleID", "RoleName", user.RoleID);
            return View(user);
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = new UserDAL().ViewDetail(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new UserDAL().Delete(id);
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

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
    public class CommentsController : BaseController
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Product).Include(c => c.User);
            return View(comments.ToList());
        }

        // GET: Admin/Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var comment = new CommentDAL().ViewDetail(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Admin/Comments/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: Admin/Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,UserID,ProductID,CommentContent,CreateDate,CreateUser,ModifiedDate,ModifiedUser,IsActive")] Comment comment)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new CommentDAL();

                comment.CreateUser = UserSession.UserID;

                int id = _dal.Insert(comment);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Comments");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm bình luận ko thành công");
                }
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", comment.ProductID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", comment.UserID);
            return View(comment);
        }

        // GET: Admin/Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var comment = new CommentDAL().ViewDetail(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", comment.ProductID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", comment.UserID);
            return View(comment);
        }

        // POST: Admin/Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentID,UserID,ProductID,CommentContent,CreateDate,CreateUser,ModifiedDate,ModifiedUser,IsActive")] Comment comment)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new CommentDAL();

                comment.ModifiedUser = UserSession.UserID;

                var _result = _dal.Update(comment);
                if (_result)
                {
                    return RedirectToAction("Index", "Comments");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật bình luận ko thành công");
                }
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", comment.ProductID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", comment.UserID);
            return View(comment);
        }

        // GET: Admin/Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var comment = new CommentDAL().ViewDetail(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Admin/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new CommentDAL().Delete(id);
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

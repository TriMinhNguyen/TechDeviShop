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
using PagedList;

namespace TechDeviShopVs002.Areas.Admin.Controllers
{
    public class ProductsController : BaseController
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/Products
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

            var products = db.Products.Include(p => p.Category).Include(p => p.Suppliers);
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductName.Contains(searchString)
                                       || s.Suppliers.SupplierName.Contains(searchString) 
                                       || s.Category.CategoryName.Contains(searchString));
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(products.OrderBy(u => u.ProductName).ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = new ProductDAL().ViewDetail(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,ProductCode,MetaTitle,Description,Image,MoreImage,Price,PromotionPrice,IncludeVAT,Quantity,SupplierID,CategoryID,Warranty,CreateDate,CreateUser,ModifiedDate,ModifiedUser,MetalKeywords,MetalDescriptions,IsActive,TopHot,ViewCount,CpuChip,CpuType,CpuSpeed,CpuMaxSpeed,BusSpeed,Ram,RamType,BusRamSpeed,MaxRam,HardDrive,Size,Weight,Color,Material,ScreenSize,Resolution,ScreenTechnology,TouchScreen,GraphicsCard,Sound,ConnectionPort,WirelessConnection,MemoryCardSlot,OpticalDiskDrive,Webcam,KeyboardLights,PinType,Pin,OperatingSystem,OtherInfo")] Product product)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new ProductDAL();

                product.CreateUser = UserSession.UserID;

                int id = _dal.Insert(product);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm san pham ko thành công");
                }
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", product.SupplierID);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = new ProductDAL().ViewDetail(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", product.SupplierID);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,ProductCode,MetaTitle,Description,Image,MoreImage,Price,PromotionPrice,IncludeVAT,Quantity,SupplierID,CategoryID,Warranty,CreateDate,CreateUser,ModifiedDate,ModifiedUser,MetalKeywords,MetalDescriptions,IsActive,TopHot,ViewCount,CpuChip,CpuType,CpuSpeed,CpuMaxSpeed,BusSpeed,Ram,RamType,BusRamSpeed,MaxRam,HardDrive,Size,Weight,Color,Material,ScreenSize,Resolution,ScreenTechnology,TouchScreen,GraphicsCard,Sound,ConnectionPort,WirelessConnection,MemoryCardSlot,OpticalDiskDrive,Webcam,KeyboardLights,PinType,Pin,OperatingSystem,OtherInfo")] Product product)
        {
            var UserSession = (UserLogin)Session[TechDeviShopVs002.Common.CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var _dal = new ProductDAL();

                product.ModifiedUser = UserSession.UserID;

                var _result = _dal.Update(product);
                if (_result)
                {
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật san pham ko thành công");
                }
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", product.SupplierID);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = new ProductDAL().ViewDetail(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new ProductDAL().Delete(id);
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

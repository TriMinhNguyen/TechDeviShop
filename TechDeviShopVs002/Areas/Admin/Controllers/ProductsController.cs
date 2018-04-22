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
    public class ProductsController : Controller
    {
        private TechDeviShopDBContext db = new TechDeviShopDBContext();

        // GET: Admin/Products
        public ActionResult Index()
        {
            var products = db.Product.Include(p => p.Category).Include(p => p.Suppliers);
            return View(products.ToList());
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
            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,ProductCode,MetaTitle,Description,Image,MoreImage,Price,PromotionPrice,IncludeVAT,Quantity,SupplierID,CategoryID,Warranty,CreateDate,CreateBy,ModifiedDate,ModifiedBy,MetalKeywords,MetalDescriptions,Status,TopHot,ViewCount,CpuChip,CpuType,CpuSpeed,CpuMaxSpeed,BusSpeed,Ram,RamType,BusRamSpeed,MaxRam,HardDrive,Size,Weight,Color,Material,ScreenSize,Resolution,ScreenTechnology,TouchScreen,GraphicsCard,Sound,ConnectionPort,WirelessConnection,MemoryCardSlot,OpticalDiskDrive,Webcam,KeyboardLights,PinType,Pin,OperatingSystem,OtherInfo")] Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAL();

                int id = dao.Insert(product);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm san pham ko thành công");
                }
            }

            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "CategoryName", product.CategoryID);
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
            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", product.SupplierID);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,ProductCode,MetaTitle,Description,Image,MoreImage,Price,PromotionPrice,IncludeVAT,Quantity,SupplierID,CategoryID,Warranty,CreateDate,CreateBy,ModifiedDate,ModifiedBy,MetalKeywords,MetalDescriptions,Status,TopHot,ViewCount,CpuChip,CpuType,CpuSpeed,CpuMaxSpeed,BusSpeed,Ram,RamType,BusRamSpeed,MaxRam,HardDrive,Size,Weight,Color,Material,ScreenSize,Resolution,ScreenTechnology,TouchScreen,GraphicsCard,Sound,ConnectionPort,WirelessConnection,MemoryCardSlot,OpticalDiskDrive,Webcam,KeyboardLights,PinType,Pin,OperatingSystem,OtherInfo")] Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAL();

                var _result = dao.Update(product);
                if (_result)
                {
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật san pham ko thành công");
                }
            }
            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "CategoryName", product.CategoryID);
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

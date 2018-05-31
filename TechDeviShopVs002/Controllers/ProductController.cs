using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechDeviShopVs002.DAL;

namespace TechDeviShopVs002.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ViewBag.productSupplier = new SupplierDAL().ListAll();
            var _product = new ProductDAL().ListALl();
            return View(_product);
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new CategoryDAL().ListAll();
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult ProductSupplier()
        {
            var model = new SupplierDAL().ListAll();
            return PartialView(model);
        }

        public ActionResult Category(int? Cateid, int page =1, int pageSize = 1)
        {
            ViewBag.productSupplier = new SupplierDAL().ListAll();
            var _category = new CategoryDAL().ViewDetail(Cateid);
            ViewBag.Category = _category;
            int totalRecord = 0;
            var _model = new ProductDAL().ListByCateID(Cateid, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(_model);
        }

        public ActionResult Detail(int id)
        {
            var product = new ProductDAL().ViewDetail(id);
            
            return View(product);
        }
    }
}
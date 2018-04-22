using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class ProductDAL
    {
        TechDeviShopDBContext db = null;

        public ProductDAL()
        {
            db = new TechDeviShopDBContext();
        }
        
        public List<Product> ListALl()
        {
            return db.Product.Where(x => x.Status == true).ToList();
        }

        public Product GetByProductName(string _productName)
        {
            return db.Product.SingleOrDefault(x => x.ProductName == _productName);
        }

        public int Insert(Product entity)
        {
            entity.CreateDate = DateTime.Now;
            db.Product.Add(entity);
            db.SaveChanges();
            return entity.ProductID;
        }

        public bool Update(Product entity)
        {
            try
            {
                var _product = db.Product.Find(entity.ProductID);
                _product.ProductName = entity.ProductName;
                _product.ProductCode = entity.ProductCode;
                _product.MetaTitle = entity.MetaTitle;
                _product.Description = entity.Description;
                _product.Image = entity.Image;
                _product.MoreImage = entity.MoreImage;
                _product.Price = entity.Price;
                _product.PromotionPrice = entity.PromotionPrice;
                _product.IncludeVAT = entity.IncludeVAT;
                _product.Quantity = entity.Quantity;
                _product.SupplierID = entity.SupplierID;
                _product.CategoryID = entity.CategoryID;
                _product.Warranty = entity.Warranty;
                _product.CreateDate = entity.CreateDate;
                _product.CreateBy = entity.CreateBy;
                _product.ModifiedDate = entity.ModifiedDate;
                _product.ModifiedBy = entity.ModifiedBy;
                _product.MetalKeywords = entity.MetalKeywords;
                _product.MetalDescriptions = entity.MetalDescriptions;
                _product.Status = entity.Status;
                _product.TopHot = entity.TopHot;
                _product.ViewCount = entity.ViewCount;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Product ViewDetail(int? id)
        {
            return db.Product.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _product = db.Product.Find(id);
                db.Product.Remove(_product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
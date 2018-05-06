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
            return db.Products.Where(x => x.IsActive == true).ToList();
        }

        public List<Product> ListALlVsNotActive()
        {
            return db.Products.ToList();
        }

        public Product GetByProductName(string _productName)
        {
            return db.Products.SingleOrDefault(x => x.ProductName == _productName);
        }

        public int Insert(Product entity)
        {
            entity.CreateDate = DateTime.Now;
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ProductID;
        }

        public bool Update(Product entity)
        {
            try
            {
                var _product = db.Products.Find(entity.ProductID);
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
                _product.ModifiedDate = entity.ModifiedDate;
                _product.ModifiedBy = entity.ModifiedBy;
                _product.MetalKeywords = entity.MetalKeywords;
                _product.MetalDescriptions = entity.MetalDescriptions;
                _product.IsActive = entity.IsActive;
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
            return db.Products.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _product = db.Products.Find(id);
                db.Products.Remove(_product);
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
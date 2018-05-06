using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class ProductContentDAL
    {
        TechDeviShopDBContext db = null;

        public ProductContentDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public List<ProductContent> ListALl()
        {
            return db.ProductContents.Where(x => x.Status == true).ToList();
        }

        public ProductContent GetByProductName(string _prcName)
        {
            return db.ProductContents.SingleOrDefault(x => x.ProductName == _prcName);
        }

        public int Insert(ProductContent entity)
        {
            entity.CreateDate = DateTime.Now;
            db.ProductContents.Add(entity);
            db.SaveChanges();
            return entity.ProductContentID;
        }

        public bool Update(ProductContent entity)
        {
            try
            {
                var _prc = db.ProductContents.Find(entity.ProductContentID);
                _prc.ProductName = entity.ProductName;
                _prc.MetaTitle = entity.MetaTitle;
                _prc.Description = entity.Description;
                _prc.Image = entity.Image;
                _prc.CategoryID = entity.CategoryID;
                _prc.Detail = entity.Detail;
                _prc.Warranty = entity.Warranty;
                _prc.CreateDate = entity.CreateDate;
                _prc.CreateBy = entity.CreateBy;
                _prc.ModifiedDate = entity.ModifiedDate;
                _prc.ModifiedBy = entity.ModifiedBy;
                _prc.MetalKeywords = entity.MetalKeywords;
                _prc.MetalDescriptions = entity.MetalDescriptions;
                _prc.Status = entity.Status;
                _prc.TopHot = entity.TopHot;
                _prc.ViewCount = entity.ViewCount;
                _prc.Tag = entity.Tag;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ProductContent ViewDetail(int? id)
        {
            return db.ProductContents.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _prc = db.ProductContents.Find(id);
                db.ProductContents.Remove(_prc);
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
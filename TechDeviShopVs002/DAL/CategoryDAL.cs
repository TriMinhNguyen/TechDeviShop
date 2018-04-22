using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class CategoryDAL
    {
        TechDeviShopDBContext db = null;

        public CategoryDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public int Insert(Category entity)
        {
            entity.CreateDate = DateTime.Now;
            db.Category.Add(entity);
            db.SaveChanges();
            return entity.CategoryID;
        }

        public bool Update(Category entity)
        {
            try
            {
                var _Cate = db.Category.Find(entity.CategoryID);
                _Cate.CategoryName = entity.CategoryName;
                _Cate.CreateBy = entity.CreateBy;
                _Cate.CreateDate = entity.CreateDate;
                _Cate.DisplayOrder = entity.DisplayOrder;
                _Cate.MetalDescriptions = entity.MetalDescriptions;
                _Cate.MetalKeywords = entity.MetalKeywords;
                _Cate.MetaTitle = entity.MetaTitle;
                _Cate.ModifiedBy = entity.ModifiedBy;
                _Cate.ModifiedDate = DateTime.Now;
                _Cate.ParentID = entity.ParentID;
                _Cate.SeoTitle = entity.SeoTitle;
                _Cate.ShowOnHome = entity.ShowOnHome;
                _Cate.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Category GetByCategoryName(string _categoryName)
        {
            return db.Category.SingleOrDefault(x => x.CategoryName == _categoryName);
        }

        public Category ViewDetail(int? id)
        {
            return db.Category.Find(id);
        }
        
        public bool Delete(int id)
        {
            try
            {
                var _Cate = db.Category.Find(id);
                db.Category.Remove(_Cate);
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
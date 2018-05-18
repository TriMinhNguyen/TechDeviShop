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
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.CategoryID;
        }

        public bool Update(Category entity)
        {
            try
            {
                var _Cate = db.Categories.Find(entity.CategoryID);
                _Cate.CategoryName = entity.CategoryName;
                _Cate.MetaTitle = entity.MetaTitle;
                _Cate.ParentID = entity.ParentID;
                _Cate.DisplayOrder = entity.DisplayOrder;
                _Cate.SeoTitle = entity.SeoTitle;
                _Cate.ModifiedDate = DateTime.Now;
                _Cate.ModifiedBy = entity.ModifiedBy;
                _Cate.MetalDescriptions = entity.MetalDescriptions;
                _Cate.MetalKeywords = entity.MetalKeywords;
                _Cate.IsActive = entity.IsActive;
                _Cate.ShowOnHome = entity.ShowOnHome;
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
            return db.Categories.SingleOrDefault(x => x.CategoryName == _categoryName);
        }

        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.IsActive == true).OrderBy(x => x.DisplayOrder).ToList();
        }
        
        public Category ViewDetail(int? id)
        {
            return db.Categories.Find(id);
        }
        
        public bool Delete(int id)
        {
            try
            {
                var _Cate = db.Categories.Find(id);
                db.Categories.Remove(_Cate);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class ArticleCategoryDAL
    {
        TechDeviShopDBContext db = null;

        public ArticleCategoryDAL()
        {
            db = new TechDeviShopDBContext(); 
        }

        public int Insert(ArticleCategory entity)
        {
            entity.CreateDate = DateTime.Now;
            db.ArticleCategories.Add(entity);
            db.SaveChanges();
            return entity.ArticleCategoryID;
        }

        public bool Update(ArticleCategory entity)
        {
            try
            {
                var _Cate = db.ArticleCategories.Find(entity.ArticleCategoryID);
                _Cate.ArticleCategoryName = entity.ArticleCategoryName;
                _Cate.Description = entity.Description;
                _Cate.Image = entity.Image;
                _Cate.MetaTitle = entity.MetaTitle;
                _Cate.ParentID = entity.ParentID;
                _Cate.DisplayOrder = entity.DisplayOrder;
                _Cate.SeoTitle = entity.SeoTitle;
                _Cate.MetaDescription = entity.MetaDescription;
                _Cate.MetaKeywords = entity.MetaKeywords;
                _Cate.CreateDate = entity.CreateDate;
                _Cate.CreateUser = entity.CreateUser;
                _Cate.ModifiedDate = DateTime.Now;
                _Cate.ModifiedUser = entity.ModifiedUser;
                _Cate.IsActive = entity.IsActive;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ArticleCategory GetByArticleCategoryName(string _ArticlecateName)
        {
            return db.ArticleCategories.SingleOrDefault(x => x.ArticleCategoryName == _ArticlecateName);
        }

        public List<ArticleCategory> ListAll()
        {
            return db.ArticleCategories.Where(x => x.IsActive == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        public ArticleCategory ViewDetail(int? id)
        {
            return db.ArticleCategories.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _Cate = db.ArticleCategories.Find(id);
                db.ArticleCategories.Remove(_Cate);
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
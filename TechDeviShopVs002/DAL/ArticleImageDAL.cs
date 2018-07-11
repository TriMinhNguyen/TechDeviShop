using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class ArticleImageDAL
    {
        TechDeviShopDBContext db = null;

        public ArticleImageDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public int Insert(ArticleImage entity)
        {
            entity.CreateDate = DateTime.Now;
            db.ArticleImages.Add(entity);
            db.SaveChanges();
            return entity.ArticleImageID;
        }

        public bool Update(ArticleImage entity)
        {
            try
            {
                var _Cate = db.ArticleImages.Find(entity.ArticleImageID);
                _Cate.ArticleID = entity.ArticleID;
                _Cate.MetaTitle = entity.MetaTitle;
                _Cate.Description = entity.Description;
                _Cate.Image = entity.Image;
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
        
        public List<ArticleImage> ListAll()
        {
            return db.ArticleImages.Where(x => x.IsActive == true).ToList();
        }

        public ArticleImage ViewDetail(int? id)
        {
            return db.ArticleImages.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _Cate = db.ArticleImages.Find(id);
                db.ArticleImages.Remove(_Cate);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ArticleImage> ListByArticleID(int id)
        {
            return db.ArticleImages.Where(x => x.ArticleID == id).OrderByDescending(x => x.CreateDate).Take(id).ToList();
        }
    }
}
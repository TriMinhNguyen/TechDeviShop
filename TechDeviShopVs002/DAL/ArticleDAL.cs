using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class ArticleDAL
    {
        TechDeviShopDBContext db = null;

        public ArticleDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public int Insert(Article entity)
        {
            entity.CreateDate = DateTime.Now;
            db.Articles.Add(entity);
            db.SaveChanges();
            return entity.ArticleID;
        }

        public bool Update(Article entity)
        {
            try
            {
                var _Cate = db.Articles.Find(entity.ArticleID);
                _Cate.ArticleCategoryID = entity.ArticleCategoryID;
                _Cate.Title = entity.Title;
                _Cate.MetaTitle = entity.MetaTitle;
                _Cate.ArticleContent = entity.ArticleContent;
                _Cate.Image = entity.Image;
                _Cate.Tag = entity.Tag;
                _Cate.ViewCount = entity.ViewCount;
                _Cate.Votes = entity.Votes;
                _Cate.TotalRating = entity.TotalRating;
                _Cate.Approved = entity.Approved;
                _Cate.ApprovedUser = entity.ApprovedUser;
                _Cate.ApprovedDate = entity.ApprovedDate;
                _Cate.CreateDate = entity.CreateDate;
                _Cate.CreateUser = entity.CreateUser;
                _Cate.ModifiedDate = DateTime.Now;
                _Cate.ModifiedUser = entity.ModifiedUser;
                _Cate.MetalKeywords = entity.MetalKeywords;
                _Cate.MetalDescriptions = entity.MetalDescriptions;
                _Cate.IsActive = entity.IsActive;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Article GetByArticleCategoryID(int _ArticlecateID)
        {
            return db.Articles.SingleOrDefault(x => x.ArticleCategoryID == _ArticlecateID);
        }

        public List<Article> ListAll()
        {
            return db.Articles.Where(x => x.IsActive == true).ToList();
        }

        public List<Article> ListByArticleCategory(int id)
        {
            return db.Articles.Where(x => x.IsActive == true && x.ArticleCategoryID == id).ToList();
        }

        public Article ViewDetail(int? id)
        {
            return db.Articles.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _Cate = db.Articles.Find(id);
                db.Articles.Remove(_Cate);
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
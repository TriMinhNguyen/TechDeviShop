using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class CommentDAL
    {
        TechDeviShopDBContext db = null;

        public CommentDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public int Insert(Comment entity)
        {
            entity.CreateDate = DateTime.Now;
            db.Comments.Add(entity);
            db.SaveChanges();
            return entity.CommentID;
        }

        public bool Update(Comment entity)
        {
            try
            {
                var _comment = db.Comments.Find(entity.CommentID);
                _comment.ArticleID = entity.ArticleID;
                _comment.ProductID = entity.ProductID;
                _comment.Email = entity.Email;
                _comment.Name = entity.Name;
                _comment.CommentContent = entity.CommentContent;
                _comment.CreateDate = entity.CreateDate;
                _comment.CreateUser = entity.CreateUser;
                _comment.ModifiedDate = DateTime.Now;
                _comment.ModifiedUser = entity.ModifiedUser;
                _comment.IsActive = entity.IsActive;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Comment ViewDetail(int? id)
        {
            return db.Comments.Find(id);
        }

        public List<Comment> ListByProductID(int id)
        {
            return db.Comments.Where(x => x.ProductID == id).OrderByDescending(x => x.CreateDate).ToList();
        }

        public bool Delete(int id)
        {
            try
            {
                var _comment = db.Comments.Find(id);
                db.Comments.Remove(_comment);
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
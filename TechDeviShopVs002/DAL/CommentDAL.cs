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

        public int Insert(Comments entity)
        {
            entity.CreateDate = DateTime.Now;
            db.Comments.Add(entity);
            db.SaveChanges();
            return entity.CommentID;
        }

        public bool Update(Comments entity)
        {
            try
            {
                var _comment = db.Comments.Find(entity.CommentID);
                _comment.UserID = entity.UserID;
                _comment.ProductID = entity.ProductID;
                _comment.CommentContent = entity.CommentContent;
                _comment.CreateDate = entity.CreateDate;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Comments ViewDetail(int? id)
        {
            return db.Comments.Find(id);
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
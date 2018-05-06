using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class FeedbackDAL
    {
        TechDeviShopDBContext db = null;

        public FeedbackDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public int Insert(Feedback entity)
        {
            entity.CreateDate = DateTime.Now;
            db.Feedbacks.Add(entity);
            db.SaveChanges();
            return entity.FeedbackID;
        }

        public bool Update(Feedback entity)
        {
            try
            {
                var _feedback = db.Feedbacks.Find(entity.FeedbackID);
                _feedback.Name = entity.Name;
                _feedback.Phone = entity.Phone;
                _feedback.Email = entity.Email;
                _feedback.Address = entity.Address;
                _feedback.Content = entity.Content;
                _feedback.CreateDate = entity.CreateDate;
                _feedback.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Feedback ViewDetail(int? id)
        {
            return db.Feedbacks.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _feedback = db.Feedbacks.Find(id);
                db.Feedbacks.Remove(_feedback);
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
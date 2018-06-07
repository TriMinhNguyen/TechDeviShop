using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class PaymentStatusDAL
    {
        TechDeviShopDBContext db = null;

        public PaymentStatusDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public List<PaymentStatu> ListALl()
        {
            return db.PaymentStatus.ToList();
        }

        public int Insert(PaymentStatu entity)
        {
            entity.CreateDate = DateTime.Now;
            db.PaymentStatus.Add(entity);
            db.SaveChanges();
            return entity.PaymentStatusID;
        }

        public bool Update(PaymentStatu entity)
        {
            try
            {
                var _paystatus = db.PaymentStatus.Find(entity.PaymentStatusID);
                _paystatus.Name = entity.Name;
                _paystatus.Note = entity.Note;
                _paystatus.ModifiedDate = DateTime.Now;
                _paystatus.ModifiedUser = entity.ModifiedUser;
                _paystatus.CreateDate = entity.CreateDate;
                _paystatus.CreateUser = entity.CreateUser;
                _paystatus.IsActive = entity.IsActive;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public PaymentStatu ViewDetail(int? id)
        {
            return db.PaymentStatus.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _paystatus = db.PaymentStatus.Find(id);
                db.PaymentStatus.Remove(_paystatus);
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
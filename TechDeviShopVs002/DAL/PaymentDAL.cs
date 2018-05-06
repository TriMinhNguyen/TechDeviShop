using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class PaymentDAL
    {
        TechDeviShopDBContext db = null;

        public PaymentDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public List<Payment> ListALl()
        {
            return db.Payments.ToList();
        }

        public int Insert(Payment entity)
        {
            entity.CreateDate = DateTime.Now;
            db.Payments.Add(entity);
            db.SaveChanges();
            return entity.PaymentID;
        }

        public bool Update(Payment entity)
        {
            try
            {
                var _payment = db.Payments.Find(entity.PaymentID);
                _payment.OrderID = entity.OrderID;
                _payment.PaymentMethodID = entity.PaymentMethodID;
                _payment.PaymentStatusID = entity.PaymentStatusID;
                _payment.PaymentDate = entity.PaymentDate;
                _payment.TotalPrice = entity.TotalPrice;
                _payment.Note = entity.Note;
                _payment.ModifiedDate = DateTime.Now;
                _payment.ModifiedBy = entity.ModifiedBy;
                _payment.TransactionID = entity.TransactionID;
                _payment.TrackingID = entity.TrackingID;
                _payment.IsActive = entity.IsActive;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Payment ViewDetail(int? id)
        {
            return db.Payments.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _payment = db.Payments.Find(id);
                db.Payments.Remove(_payment);
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
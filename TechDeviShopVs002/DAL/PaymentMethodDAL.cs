using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class PaymentMethodDAL
    {
        TechDeviShopDBContext db = null;

        public PaymentMethodDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public List<PaymentMethod> ListALl()
        {
            return db.PaymentMethods.ToList();
        }

        public int Insert(PaymentMethod entity)
        {
            entity.CreateDate = DateTime.Now;
            db.PaymentMethods.Add(entity);
            db.SaveChanges();
            return entity.PaymentMethodID;
        }

        public bool Update(PaymentMethod entity)
        {
            try
            {
                var _paymentMethod = db.PaymentMethods.Find(entity.PaymentMethodID);
                _paymentMethod.Name = entity.Name;
                _paymentMethod.Note = entity.Note;
                _paymentMethod.ModifiedDate = DateTime.Now;
                _paymentMethod.ModifiedUser = entity.ModifiedUser;
                _paymentMethod.CreateDate = entity.CreateDate;
                _paymentMethod.CreateUser = entity.CreateUser;
                _paymentMethod.IsActive = entity.IsActive;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public PaymentMethod ViewDetail(int? id)
        {
            return db.PaymentMethods.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _paymentMethod = db.PaymentMethods.Find(id);
                db.PaymentMethods.Remove(_paymentMethod);
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
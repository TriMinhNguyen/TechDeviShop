using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class ShippingMethodDAL
    {
        TechDeviShopDBContext db = null;

        public ShippingMethodDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public int Insert(ShippingMethod entity)
        {
            entity.CreateDate = DateTime.Now;
            db.ShippingMethod.Add(entity);
            db.SaveChanges();
            return entity.ShippingMethodID;
        }

        public bool Update(ShippingMethod entity)
        {
            try
            {
                var _shippingMethod = db.ShippingMethod.Find(entity.ShippingMethodID);
                _shippingMethod.Title = entity.Title;
                _shippingMethod.Price = entity.Price;
                _shippingMethod.CreateDate = entity.CreateDate;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ShippingMethod ViewDetail(int? id)
        {
            return db.ShippingMethod.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _shippingMethod = db.ShippingMethod.Find(id);
                db.ShippingMethod.Remove(_shippingMethod);
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
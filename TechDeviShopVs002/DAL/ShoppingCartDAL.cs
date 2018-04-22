using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class ShoppingCartDAL
    {
        TechDeviShopDBContext db = null;

        public ShoppingCartDAL()
        {
            db = new TechDeviShopDBContext(); 
        }

        public int Insert(ShoppingCart entity)
        {
            entity.CreateDate = DateTime.Now;
            db.ShoppingCart.Add(entity);
            db.SaveChanges();
            return entity.ShoppingCartID;
        }

        public bool Update(ShoppingCart entity)
        {
            try
            {
                var _shoppingCart = db.ShoppingCart.Find(entity.ShoppingCartID);
                _shoppingCart.ShippingMethodID = entity.ShippingMethodID;
                _shoppingCart.ShippingCost = entity.ShippingCost;
                _shoppingCart.SubTotal = entity.SubTotal;
                _shoppingCart.TotalPrice = entity.TotalPrice;
                _shoppingCart.CreateDate = entity.CreateDate;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ShoppingCart ViewDetail(int? id)
        {
            return db.ShoppingCart.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _shoppingCart = db.ShoppingCart.Find(id);
                db.ShoppingCart.Remove(_shoppingCart);
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
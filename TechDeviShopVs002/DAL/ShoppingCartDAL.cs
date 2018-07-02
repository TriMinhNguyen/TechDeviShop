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
            entity.ShoppingDate = DateTime.Now;
            entity.ExpireDate = DateTime.Now.AddDays(7);
            db.ShoppingCarts.Add(entity);
            db.SaveChanges();
            return entity.ShoppingCartID;
        }

        public bool Update(ShoppingCart entity)
        {
            try
            {
                var _shoppingCart = db.ShoppingCarts.Find(entity.ShoppingCartID);
                _shoppingCart.CustomerID = entity.CustomerID;
                _shoppingCart.ShoppingDate = entity.ShoppingDate;
                _shoppingCart.ExpireDate = DateTime.Now.AddDays(7);
                _shoppingCart.Note = entity.Note;
                _shoppingCart.ModifiedDate = DateTime.Now;
                _shoppingCart.ModifiedUser = entity.ModifiedUser;
                _shoppingCart.CreateDate = entity.CreateDate;
                _shoppingCart.CreateUser = entity.CreateUser;
                _shoppingCart.IsActive = entity.IsActive;
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
            return db.ShoppingCarts.Find(id);
        }

        public ShoppingCart FindByCus(int id)
        {
            DateTime _tnow = DateTime.Now;
            var _sc = db.ShoppingCarts.SingleOrDefault(x => x.CustomerID == id && x.ExpireDate > _tnow);
            return _sc;
        }

        public bool Delete(int id)
        {
            try
            {
                var _shoppingCart = db.ShoppingCarts.Find(id);
                db.ShoppingCarts.Remove(_shoppingCart);
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
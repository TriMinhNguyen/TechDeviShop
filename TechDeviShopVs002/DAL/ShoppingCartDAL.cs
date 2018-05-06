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
            db.ShoppingCarts.Add(entity);
            db.SaveChanges();
            return entity.ShoppingCartID;
        }

        public bool Update(ShoppingCart entity)
        {
            try
            {
                var _shoppingCart = db.ShoppingCarts.Find(entity.ShoppingCartID);
                _shoppingCart.ShoppingDate = entity.ShoppingDate;
                _shoppingCart.ExpireDate = entity.ExpireDate;
                _shoppingCart.Note = entity.Note;
                _shoppingCart.ModifiedDate = DateTime.Now;
                _shoppingCart.ModifiedBy = entity.ModifiedBy;
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
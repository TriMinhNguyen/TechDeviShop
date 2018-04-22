﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class ShoppingCartDetailDAL
    {
        TechDeviShopDBContext db = null;

        public ShoppingCartDetailDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public int Insert(ShoppingCartDetails entity)
        {
            entity.CreateDate = DateTime.Now;
            db.ShoppingCartDetails.Add(entity);
            db.SaveChanges();
            return entity.ShoppingCartDetailID;
        }

        public bool Update(ShoppingCartDetails entity)
        {
            try
            {
                var _scd = db.ShoppingCartDetails.Find(entity.ShoppingCartDetailID);
                _scd.ShoppingCartID = entity.ShoppingCartID;
                _scd.ProductID = entity.ProductID;
                _scd.Title = entity.Title;
                _scd.UnitPrice = entity.UnitPrice;
                _scd.Quantity = entity.Quantity;
                _scd.CreateDate = entity.CreateDate;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ShoppingCartDetails ViewDetail(int? id)
        {
            return db.ShoppingCartDetails.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _scd = db.ShoppingCartDetails.Find(id);
                db.ShoppingCartDetails.Remove(_scd);
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
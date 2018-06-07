using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class OrderStatusDAL
    {
        TechDeviShopDBContext db = null;

        public OrderStatusDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public List<OrderStatu> ListALl()
        {
            return db.OrderStatus.ToList();
        }

        public int Insert(OrderStatu entity)
        {
            entity.CreateDate = DateTime.Now;
            db.OrderStatus.Add(entity);
            db.SaveChanges();
            return entity.OrderStatusID;
        }

        public bool Update(OrderStatu entity)
        {
            try
            {
                var _orderStatus = db.OrderStatus.Find(entity.OrderStatusID);
                _orderStatus.OrderStatusName = entity.OrderStatusName;
                _orderStatus.Description = entity.Description;
                _orderStatus.DisplayOrder = entity.DisplayOrder;
                _orderStatus.ModifiedDate = DateTime.Now;
                _orderStatus.ModifiedUser = entity.ModifiedUser;
                _orderStatus.CreateDate = entity.CreateDate;
                _orderStatus.CreateUser = entity.CreateUser;
                _orderStatus.IsActive = entity.IsActive;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public OrderStatu ViewDetail(int? id)
        {
            return db.OrderStatus.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _orderStatus = db.OrderStatus.Find(id);
                db.OrderStatus.Remove(_orderStatus);
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
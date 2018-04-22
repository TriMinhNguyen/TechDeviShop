using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class OrderDetailsDAL
    {
        TechDeviShopDBContext db = null;

        public OrderDetailsDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public List<OrderDetails> ListALl()
        {
            return db.OrderDetails.ToList();
        }
        
        public int Insert(OrderDetails entity)
        {
            db.OrderDetails.Add(entity);
            db.SaveChanges();
            return entity.OrderDetailID;
        }

        public bool Update(OrderDetails entity)
        {
            try
            {
                var _orderDetail = db.OrderDetails.Find(entity.OrderDetailID);
                _orderDetail.OrderID = entity.OrderID;
                _orderDetail.ProductID = entity.ProductID;
                _orderDetail.Title = entity.Title;
                _orderDetail.UnitPrice = entity.UnitPrice;
                _orderDetail.Quantity = entity.Quantity;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public OrderDetails ViewDetail(int? id)
        {
            return db.OrderDetails.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _orderDetail = db.OrderDetails.Find(id);
                db.OrderDetails.Remove(_orderDetail);
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
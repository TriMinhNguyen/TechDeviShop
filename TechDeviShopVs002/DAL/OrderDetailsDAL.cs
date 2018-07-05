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

        public List<OrderDetail> ListALl()
        {
            return db.OrderDetails.ToList();
        }
        
        public int Insert(OrderDetail entity)
        {
            entity.CreateDate = DateTime.Now;
            db.OrderDetails.Add(entity);
            db.SaveChanges();
            return entity.OrderDetailID;
        }

        public bool Update(OrderDetail entity)
        {
            try
            {
                var _orderDetail = db.OrderDetails.Find(entity.OrderDetailID);
                _orderDetail.OrderID = entity.OrderID;
                _orderDetail.ProductID = entity.ProductID;
                _orderDetail.ProductName = entity.ProductName;
                _orderDetail.ProductCode = entity.ProductCode;
                _orderDetail.UnitPrice = entity.UnitPrice;
                _orderDetail.Quantity = entity.Quantity;
                _orderDetail.PromotionPrice = entity.PromotionPrice;
                _orderDetail.ModifiedDate = DateTime.Now;
                _orderDetail.ModifiedUser = entity.ModifiedUser;
                _orderDetail.CreateDate = entity.CreateDate;
                _orderDetail.CreateUser = entity.CreateUser;
                _orderDetail.IsActive = entity.IsActive;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public OrderDetail ViewDetail(int? id)
        {
            return db.OrderDetails.Find(id);
        }

        public List<OrderDetail> ListByOrderID(int id)
        {
            return db.OrderDetails.Where(x => x.OrderID == id).OrderByDescending(x => x.CreateDate).Take(id).ToList();
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
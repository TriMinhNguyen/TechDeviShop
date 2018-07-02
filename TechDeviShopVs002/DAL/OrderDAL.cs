using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class OrderDAL
    {
        TechDeviShopDBContext db = null;

        public OrderDAL()
        {
            db = new TechDeviShopDBContext();
        }
        
        public List<Order> ListALl()
        {
            return db.Orders.ToList();
        }
        
        public int Insert(Order entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.ShippedDate = DateTime.Now.AddDays(1);
            entity.RequiredDate = DateTime.Now.AddDays(3);
            db.Orders.Add(entity);
            db.SaveChanges();
            return entity.OrderID;
        }

        public bool Update(Order entity)
        {
            try
            {
                var _order = db.Orders.Find(entity.OrderID);
                _order.CustomerID = entity.CustomerID;
                _order.ShipperID = entity.ShipperID;
                _order.ShippingMethodID = entity.ShippingMethodID;
                _order.OrderStatusID = entity.OrderStatusID;
                _order.ShippingCost = entity.ShippingCost;
                _order.CusName = entity.CusName;
                _order.CusPhone = entity.CusPhone;
                _order.CusEmail = entity.CusEmail;
                _order.Company = entity.Company;
                _order.City = entity.City;
                _order.District = entity.District;
                _order.Address = entity.Address;
                _order.ShippingPostalCode = entity.ShippingPostalCode;
                _order.OrtherNote = entity.OrtherNote;
                _order.ShippedDate = entity.ShippedDate;
                _order.RequiredDate = entity.RequiredDate;
                _order.IsActive = entity.IsActive;
                _order.CreateDate = entity.CreateDate;
                _order.CreateUser = entity.CreateUser;
                _order.ModifiedDate = DateTime.Now;
                _order.ModifiedUser = entity.ModifiedUser;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Order ViewDetail(int? id)
        {
            return db.Orders.Find(id);
        }

        public List<Order> OrderHistory(int id)
        {
            DateTime _tnow = DateTime.Now;
            var order = db.Orders.Where(x => x.CustomerID == id && x.RequiredDate < _tnow).ToList();
            return order;
        }

        public List<Order> OngoingOrders(int id)
        {
            var order = db.Orders.Where(x => x.CustomerID == id && x.OrderStatusID < 4).ToList();
            return order;
        }

        public bool Delete(int id)
        {
            try
            {
                var _order = db.Orders.Find(id);
                db.Orders.Remove(_order);
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
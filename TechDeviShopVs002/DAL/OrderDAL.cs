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
        
        public List<Orders> ListALl()
        {
            return db.Orders.ToList();
        }
        
        public int Insert(Orders entity)
        {
            entity.CreateDate = DateTime.Now;
            db.Orders.Add(entity);
            db.SaveChanges();
            return entity.OrderID;
        }

        public bool Update(Orders entity)
        {
            try
            {
                var _order = db.Orders.Find(entity.OrderID);
                _order.CustomerID = entity.CustomerID;
                _order.ShipperID = entity.ShipperID;
                _order.ShippingMethodID = entity.ShippingMethodID;
                _order.ShippingCost = entity.ShippingCost;
                _order.SubTotal = entity.SubTotal;
                _order.TotalPrice = entity.TotalPrice;
                _order.CusName = entity.CusName;
                _order.CusPhone = entity.CusPhone;
                _order.CusEmail = entity.CusEmail;
                _order.Company = entity.Company;
                _order.City = entity.City;
                _order.District = entity.District;
                _order.Address = entity.Address;
                _order.ShippingPostalCode = entity.ShippingPostalCode;
                _order.OrtherNote = entity.OrtherNote;
                _order.CreateDate = entity.CreateDate;
                _order.ShippedDate = entity.ShippedDate;
                _order.TransactionID = entity.TransactionID;
                _order.TrackingID = entity.TrackingID;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Orders ViewDetail(int? id)
        {
            return db.Orders.Find(id);
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
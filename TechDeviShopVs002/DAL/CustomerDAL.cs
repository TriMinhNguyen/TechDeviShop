using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class CustomerDAL
    {
        TechDeviShopDBContext db = null;

        public CustomerDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public int Insert(Customers entity)
        {
            db.Customers.Add(entity);
            db.SaveChanges();
            return entity.CustomerID;
        }

        public bool Update(Customers entity)
        {
            try
            {
                var _cus = db.Customers.Find(entity.CustomerID);
                _cus.CustomerName = entity.CustomerName;
                _cus.CustomerGender = entity.CustomerGender;
                _cus.CustomerBirthday = entity.CustomerBirthday;
                _cus.CustomerAddress = entity.CustomerAddress;
                _cus.CustomerEmail = entity.CustomerEmail;
                _cus.CustomerPhone = entity.CustomerPhone;
                _cus.OrtherDetail = entity.OrtherDetail;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Customers GetByCusName(string _cusName)
        {
            return db.Customers.SingleOrDefault(x => x.CustomerName == _cusName);
        }

        public Customers ViewDetail(int? id)
        {
            return db.Customers.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _cus = db.Customers.Find(id);
                db.Customers.Remove(_cus);
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
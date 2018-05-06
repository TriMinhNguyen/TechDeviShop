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

        public int Insert(Customer entity)
        {
            db.Customers.Add(entity);
            db.SaveChanges();
            return entity.CustomerID;
        }

        public bool Update(Customer entity)
        {
            try
            {
                var _cus = db.Customers.Find(entity.CustomerID);
                _cus.CustomerName = entity.CustomerName;
                _cus.CustomerGender = entity.CustomerGender;
                _cus.CustomerBirthday = entity.CustomerBirthday;
                _cus.CustomerPhone = entity.CustomerPhone;
                _cus.CustomerEmail = entity.CustomerEmail;
                _cus.CustomerAddress = entity.CustomerAddress;
                _cus.CustomerCity = entity.CustomerCity;
                _cus.CustomerDistrict = entity.CustomerDistrict;
                _cus.PostCost = entity.PostCost;
                _cus.OrtherDetail = entity.OrtherDetail;
                _cus.IsActive = entity.IsActive;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Customer GetByCusName(string _cusName)
        {
            return db.Customers.SingleOrDefault(x => x.CustomerName == _cusName);
        }

        public Customer ViewDetail(int? id)
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
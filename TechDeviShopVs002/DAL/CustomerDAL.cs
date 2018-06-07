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

        public int InsertForFacebook(Customer entity)
        {
            var _cus = db.Customers.SingleOrDefault(x => x.CustomerEmail == entity.CustomerEmail);
            if (_cus == null)
            {
                db.Customers.Add(entity);
                db.SaveChanges();
                return entity.CustomerID;
            }
            else
            {
                return _cus.CustomerID;
            }
        }

        public bool Update(Customer entity)
        {
            try
            {
                var _cus = db.Customers.Find(entity.CustomerID);
                _cus.CustomerName = entity.CustomerName;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    _cus.Password = entity.Password;
                }
                _cus.Avatar = entity.Avatar;
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

        public int Login(string userName, string passWord)
        {
            var result = db.Customers.SingleOrDefault(x => x.CustomerEmail == userName);
            if (result == null)
            {
                return 0;   //"Tài khoản không tồn tại.";
            }
            else
            {
                if (result.IsActive == false)
                {
                    return -1;  //"Tài khoản đang bị khóa.";
                }
                else
                {
                    if (result.Password == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }

        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
    }
}
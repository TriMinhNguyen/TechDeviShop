using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class UserDAL
    {
        TechDeviShopDBContext db = null;

        public UserDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public int Insert(User entity)
        {
            entity.CreateDate = DateTime.Now;
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.UserID;
        }

        public int InsertForFacebook(User entity)
        {
            var user = db.Users.SingleOrDefault(x => x.UserName == entity.UserName);
            if (user == null)
            {
                db.Users.Add(entity);
                db.SaveChanges();
                return entity.UserID;
            }
            else
            {
                return user.UserID;
            }
        }

        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.UserID);
                //if(!string.IsNullOrEmpty(entity.Password))
                //{
                //    user.Password = entity.Password;
                //}
                user.CustomerID = entity.CustomerID;
                user.Name = entity.Name;
                user.Gender = entity.Gender;
                user.Birthday = entity.Birthday;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.ModifiedDate = DateTime.Now;
                user.RoleID = entity.RoleID;
                user.IsActive = entity.IsActive;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User GetByUserName(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }

        public User ViewDetail(int? id)
        {
            return db.Users.Find(id);
        }

        public int Login(string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
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

        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.UserName == userName) > 0;
        }

        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
    }
}
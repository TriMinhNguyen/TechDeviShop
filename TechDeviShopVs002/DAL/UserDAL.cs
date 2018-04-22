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
            db.User.Add(entity);
            db.SaveChanges();
            return entity.UserID;
        }

        public bool Update(User entity)
        {
            try
            {
                var user = db.User.Find(entity.UserID);
                //if(!string.IsNullOrEmpty(entity.Password))
                //{
                //    user.Password = entity.Password;
                //}
                user.Name = entity.Name;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Birthday = entity.Birthday;
                user.Gender = entity.Gender;
                user.Phone = entity.Phone;
                user.RoleID = entity.RoleID;
                user.Status = entity.Status;
                user.ModifiedDate = DateTime.Now;
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
            return db.User.SingleOrDefault(x => x.UserName == userName);
        }

        public User ViewDetail(int? id)
        {
            return db.User.Find(id);
        }

        public int Login(string userName, string passWord)
        {
            var result = db.User.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;   //"Tài khoản không tồn tại.";
            }
            else
            {
                if (result.Status == false)
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
                var user = db.User.Find(id);
                db.User.Remove(user);
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
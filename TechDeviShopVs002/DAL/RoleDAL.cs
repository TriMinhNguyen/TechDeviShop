using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class RoleDAL
    {
        TechDeviShopDBContext db = null;

        public RoleDAL()
        {
            db = new TechDeviShopDBContext(); 
        }
        
        public List<Role> ListALl()
        {
            return db.Role.ToList();
        }
        
        public int Insert(Role entity)
        {
            db.Role.Add(entity);
            db.SaveChanges();
            return entity.RoleID;
        }

        public bool Update(Role entity)
        {
            try
            {
                var _role = db.Role.Find(entity.RoleID);
                _role.RoleName = entity.RoleName;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Role ViewDetail(int? id)
        {
            return db.Role.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _role = db.Role.Find(id);
                db.Role.Remove(_role);
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
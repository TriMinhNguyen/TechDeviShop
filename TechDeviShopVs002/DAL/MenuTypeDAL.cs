using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class MenuTypeDAL
    {
        TechDeviShopDBContext db = null;

        public MenuTypeDAL()
        {
            db = new TechDeviShopDBContext();
        }
                
        public List<MenuType> ListALl()
        {
            return db.MenuTypes.ToList();
        }

        public int Insert(MenuType entity)
        {
            db.MenuTypes.Add(entity);
            db.SaveChanges();
            return entity.MenuTypeID;
        }

        public bool Update(MenuType entity)
        {
            try
            {
                var _menutype = db.MenuTypes.Find(entity.MenuTypeID);
                _menutype.Name = entity.Name;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public MenuType ViewDetail(int? id)
        {
            return db.MenuTypes.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _menutype = db.MenuTypes.Find(id);
                db.MenuTypes.Remove(_menutype);
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
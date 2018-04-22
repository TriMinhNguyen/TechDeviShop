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

        public List<MenuType> ListByGroupId(int groupID)
        {
            return db.MenuType.Where(x => x.MenuTypeID == groupID).ToList();
        }

        public List<MenuType> ListALl()
        {
            return db.MenuType.ToList();
        }

        public int Insert(MenuType entity)
        {
            db.MenuType.Add(entity);
            db.SaveChanges();
            return entity.MenuTypeID;
        }

        public bool Update(MenuType entity)
        {
            try
            {
                var _menutype = db.MenuType.Find(entity.MenuTypeID);
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
            return db.MenuType.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _menutype = db.MenuType.Find(id);
                db.MenuType.Remove(_menutype);
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
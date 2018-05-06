using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class MenuDAL
    {
        TechDeviShopDBContext db = null;

        public MenuDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public List<Menu> ListByGroupId(int groupID)
        {
            return db.Menus.Where(x => x.MenuTypeID == groupID).OrderBy(x => x.DisplayOrder).ToList();
        }

        public List<Menu> ListALl()
        {
            return db.Menus.ToList();
        }
        
        public Menu GetByMenuText(string _menuName)
        {
            return db.Menus.SingleOrDefault(x => x.Text == _menuName); 
        }

        public int Insert(Menu entity)
        {
            db.Menus.Add(entity);
            db.SaveChanges();
            return entity.MenuID;
        }

        public bool Update(Menu entity)
        {
            try
            {
                var _menu = db.Menus.Find(entity.MenuID);
                _menu.Text = entity.Text;
                _menu.Link = entity.Link;
                _menu.DisplayOrder = entity.DisplayOrder;
                _menu.Target = entity.Target;
                _menu.ParentID = entity.ParentID;
                _menu.MenuTypeID = entity.MenuTypeID;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public Menu ViewDetail(int? id)
        {
            return db.Menus.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _menu = db.Menus.Find(id);
                db.Menus.Remove(_menu);
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
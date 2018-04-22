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
            return db.Menu.Where(x => x.MenuTypeID == groupID && x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        public List<Menu> ListALl()
        {
            return db.Menu.Where(x => x.Status == true).ToList();
        }
        
        public Menu GetByMenuText(string _menuName)
        {
            return db.Menu.SingleOrDefault(x => x.Text == _menuName); 
        }

        public int Insert(Menu entity)
        {
            db.Menu.Add(entity);
            db.SaveChanges();
            return entity.MenuID;
        }

        public bool Update(Menu entity)
        {
            try
            {
                var _menu = db.Menu.Find(entity.MenuID);
                _menu.Text = entity.Text;
                _menu.Link = entity.Link;
                _menu.DisplayOrder = entity.DisplayOrder;
                _menu.Target = entity.Target;
                _menu.Status = entity.Status;
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
            return db.Menu.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _menu = db.Menu.Find(id);
                db.Menu.Remove(_menu);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class FooterDAL
    {
        TechDeviShopDBContext db = null;

        public FooterDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public Footer GetFooter()
        {
            return db.Footers.SingleOrDefault(x => x.IsActive == true);
        }

        public int Insert(Footer entity)
        {
            db.Footers.Add(entity);
            db.SaveChanges();
            return entity.FooterID;
        }

        public bool Update(Footer entity)
        {
            try
            {
                var _footer = db.Footers.Find(entity.FooterID);
                _footer.Content = entity.Content;
                _footer.DisplayOrder = entity.DisplayOrder;
                _footer.IsActive = entity.IsActive;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Footer ViewDetail(int? id)
        {
            return db.Footers.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _footer = db.Footers.Find(id);
                db.Footers.Remove(_footer);
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
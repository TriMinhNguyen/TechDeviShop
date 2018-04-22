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
            return db.Footer.SingleOrDefault(x => x.Status == true);
        }

        public string Insert(Footer entity)
        {
            db.Footer.Add(entity);
            db.SaveChanges();
            return entity.FooterID;
        }

        public bool Update(Footer entity)
        {
            try
            {
                var _footer = db.Footer.Find(entity.FooterID);
                _footer.Content = entity.Content;
                _footer.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Footer ViewDetail(string id)
        {
            return db.Footer.Find(id);
        }

        public bool Delete(string id)
        {
            try
            {
                var _footer = db.Footer.Find(id);
                db.Footer.Remove(_footer);
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
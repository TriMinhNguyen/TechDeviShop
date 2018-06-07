using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class AboutDAL
    {
        TechDeviShopDBContext db = null;

        public AboutDAL()
        {
            db = new TechDeviShopDBContext();
        }
        
        public int Insert(About entity)
        {
            entity.CreateDate = DateTime.Now;
            db.Abouts.Add(entity);
            db.SaveChanges();
            return entity.AboutID;
        }

        public bool Update(About entity)
        {
            try
            {
                var _about = db.Abouts.Find(entity.AboutID);
                _about.AboutName = entity.AboutName;
                _about.MetaTitle = entity.MetaTitle;
                _about.Description = entity.Description;
                _about.Image = entity.Image;
                _about.Detail = entity.Detail;
                _about.MetalKeywords = entity.MetalKeywords;
                _about.MetalDescriptions = entity.MetalDescriptions;
                _about.CreateDate = entity.CreateDate;
                _about.CreateUser = entity.CreateUser;
                _about.ModifiedDate = DateTime.Now;
                _about.ModifiedUser = entity.ModifiedUser;
                _about.IsActive = entity.IsActive;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public About ViewDetail(int? id)
        {
            return db.Abouts.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _about = db.Abouts.Find(id);
                db.Abouts.Remove(_about);
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
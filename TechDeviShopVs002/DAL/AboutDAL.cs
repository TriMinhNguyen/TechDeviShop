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
            db.About.Add(entity);
            db.SaveChanges();
            return entity.AboutID;
        }

        public bool Update(About entity)
        {
            try
            {
                var _about = db.About.Find(entity.AboutID);
                _about.AboutName = entity.AboutName;
                _about.MetaTitle = entity.MetaTitle;
                _about.Description = entity.Description;
                _about.Image = entity.Image;
                _about.Detail = entity.Detail;
                _about.CreateDate = entity.CreateDate;
                _about.CreateBy = entity.CreateBy;
                _about.ModifiedDate = entity.ModifiedDate;
                _about.ModifiedBy = entity.ModifiedBy;
                _about.MetalKeywords = entity.MetalKeywords;
                _about.MetalDescriptions = entity.MetalDescriptions;
                _about.Status = entity.Status;
                _about.TopHot = entity.TopHot;
                _about.ViewCount = entity.ViewCount;
                _about.Tag = entity.Tag;
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
            return db.About.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _about = db.About.Find(id);
                db.About.Remove(_about);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class SlideDAL
    {
        TechDeviShopDBContext db = null;

        public SlideDAL()
        {
            db = new TechDeviShopDBContext();
        }
        
        public List<Slide> ListALl()
        {
            return db.Slides.Where(x => x.IsActive == true).ToList();
        }
        
        public int Insert(Slide entity)
        {
            entity.CreateDate = DateTime.Now;
            db.Slides.Add(entity);
            db.SaveChanges();
            return entity.SlideID;
        }

        public bool Update(Slide entity)
        {
            try
            {
                var _slide = db.Slides.Find(entity.SlideID);
                _slide.Image = entity.Image;
                _slide.DisplayOrder = entity.DisplayOrder;
                _slide.Link = entity.Link;
                _slide.Description = entity.Description;
                _slide.CreateDate = entity.CreateDate;
                _slide.CreateUser = entity.CreateUser;
                _slide.ModifiedDate = DateTime.Now;
                _slide.ModifiedUser = entity.ModifiedUser;
                _slide.IsActive = entity.IsActive;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Slide ViewDetail(int? id)
        {
            return db.Slides.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _slide = db.Slides.Find(id);
                db.Slides.Remove(_slide);
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
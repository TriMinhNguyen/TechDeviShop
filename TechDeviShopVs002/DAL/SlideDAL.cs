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
            return db.Slide.Where(x => x.Status == true).ToList();
        }
        
        public int Insert(Slide entity)
        {
            entity.CreateDate = DateTime.Now;
            db.Slide.Add(entity);
            db.SaveChanges();
            return entity.SlideID;
        }

        public bool Update(Slide entity)
        {
            try
            {
                var _slide = db.Slide.Find(entity.SlideID);
                _slide.Image = entity.Image;
                _slide.DisplayOrder = entity.DisplayOrder;
                _slide.Link = entity.Link;
                _slide.Description = entity.Description;
                _slide.CreateDate = entity.CreateDate;
                _slide.CreateBy = entity.CreateBy;
                _slide.ModifiedDate = entity.ModifiedDate;
                _slide.ModifiedBy = entity.ModifiedBy;
                _slide.Status = entity.Status;
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
            return db.Slide.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _slide = db.Slide.Find(id);
                db.Slide.Remove(_slide);
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
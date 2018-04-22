using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class TagDAL
    {
        TechDeviShopDBContext db = null;

        public TagDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public string Insert(Tag entity)
        {
            db.Tag.Add(entity);
            db.SaveChanges();
            return entity.TagID;
        }

        public bool Update(Tag entity)
        {
            try
            {
                var _tag = db.Tag.Find(entity.TagID);
                _tag.Name = entity.Name;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Tag ViewDetail(int? id)
        {
            return db.Tag.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _tag = db.Tag.Find(id);
                db.Tag.Remove(_tag);
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
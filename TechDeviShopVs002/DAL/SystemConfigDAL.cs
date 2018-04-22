using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class SystemConfigDAL
    {
        TechDeviShopDBContext db = null;

        public SystemConfigDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public string Insert(SystemConfig entity)
        {
            db.SystemConfig.Add(entity);
            db.SaveChanges();
            return entity.SystemConfigID;
        }

        public bool Update(SystemConfig entity)
        {
            try
            {
                var _sys = db.SystemConfig.Find(entity.SystemConfigID);
                _sys.Name = entity.Name;
                _sys.Type = entity.Type;
                _sys.Value = entity.Value;
                _sys.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public SystemConfig ViewDetail(int? id)
        {
            return db.SystemConfig.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _sys = db.SystemConfig.Find(id);
                db.SystemConfig.Remove(_sys);
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
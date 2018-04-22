using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class ShipperDAL
    {
        TechDeviShopDBContext db = null;

        public ShipperDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public List<Shipper> ListALl()
        {
            return db.Shipper.Where(x => x.Status == true).ToList();
        }

        public int Insert(Shipper entity)
        {
            entity.CreateDate = DateTime.Now;
            db.Shipper.Add(entity);
            db.SaveChanges();
            return entity.ShipperID;
        }

        public bool Update(Shipper entity)
        {
            try
            {
                var _shipper = db.Shipper.Find(entity.ShipperID);
                _shipper.Name = entity.Name;
                _shipper.Email = entity.Email;
                _shipper.Phone = entity.Phone;
                _shipper.CusReviews = entity.CusReviews;
                _shipper.CreateDate = entity.CreateDate;
                _shipper.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Shipper ViewDetail(int? id)
        {
            return db.Shipper.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _shipper = db.Shipper.Find(id);
                db.Shipper.Remove(_shipper);
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
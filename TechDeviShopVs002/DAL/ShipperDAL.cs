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
            return db.Shippers.Where(x => x.IsActive == true).ToList();
        }

        public int Insert(Shipper entity)
        {
            entity.CreateDate = DateTime.Now;
            db.Shippers.Add(entity);
            db.SaveChanges();
            return entity.ShipperID;
        }

        public bool Update(Shipper entity)
        {
            try
            {
                var _shipper = db.Shippers.Find(entity.ShipperID);
                _shipper.Name = entity.Name;
                _shipper.Email = entity.Email;
                _shipper.Phone = entity.Phone;
                _shipper.Fax = entity.Fax;
                _shipper.Address = entity.Address;
                _shipper.CreateDate = entity.CreateDate;
                _shipper.CreateUser = entity.CreateUser;
                _shipper.ModifiedDate = DateTime.Now;
                _shipper.ModifiedUser = entity.ModifiedUser;
                _shipper.IsActive = entity.IsActive;
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
            return db.Shippers.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _shipper = db.Shippers.Find(id);
                db.Shippers.Remove(_shipper);
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
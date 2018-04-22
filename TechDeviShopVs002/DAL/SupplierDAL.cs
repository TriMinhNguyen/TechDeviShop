using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;

namespace TechDeviShopVs002.DAL
{
    public class SupplierDAL
    {
        TechDeviShopDBContext db = null;

        public SupplierDAL()
        {
            db = new TechDeviShopDBContext();
        }

        public int Insert(Suppliers entity)
        {
            entity.CreateDate = DateTime.Now;
            db.Suppliers.Add(entity);
            db.SaveChanges();
            return entity.SupplierID;
        }

        public bool Update(Suppliers entity)
        {
            try
            {
                var _supplier = db.Suppliers.Find(entity.SupplierID);
                _supplier.SupplierName = entity.SupplierName;
                _supplier.MetaTitle = entity.MetaTitle;
                _supplier.EmailSupport = entity.EmailSupport;
                _supplier.PhoneNumber = entity.PhoneNumber;
                _supplier.Detail = entity.Detail;
                _supplier.CreateDate = entity.CreateDate;
                _supplier.CreateBy = entity.CreateBy;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Suppliers GetByUserName(string supplierName)
        {
            return db.Suppliers.SingleOrDefault(x => x.SupplierName == supplierName);
        }

        public Suppliers ViewDetail(int? id)
        {
            return db.Suppliers.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _supplier = db.Suppliers.Find(id);
                db.Suppliers.Remove(_supplier);
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
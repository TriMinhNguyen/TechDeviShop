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

        public int Insert(Supplier entity)
        {
            entity.CreateDate = DateTime.Now;
            db.Suppliers.Add(entity);
            db.SaveChanges();
            return entity.SupplierID;
        }

        public bool Update(Supplier entity)
        {
            try
            {
                var _supplier = db.Suppliers.Find(entity.SupplierID);
                _supplier.SupplierName = entity.SupplierName;
                _supplier.MetaTitle = entity.MetaTitle;
                _supplier.EmailSupport = entity.EmailSupport;
                _supplier.PhoneNumber = entity.PhoneNumber;
                _supplier.Detail = entity.Detail;
                _supplier.ModifiedDate = DateTime.Now;
                _supplier.ModifiedUser = entity.ModifiedUser;
                _supplier.CreateDate = entity.CreateDate;
                _supplier.CreateUser = entity.CreateUser;
                _supplier.IsActive = entity.IsActive;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Supplier GetBySupplierName(string supplierName)
        {
            return db.Suppliers.SingleOrDefault(x => x.SupplierName == supplierName);
        }

        public List<Supplier> ListAll()
        {
            return db.Suppliers.Where(x => x.IsActive == true).ToList();
        }

        public Supplier ViewDetail(int? id)
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
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechDeviShopVs002.Models;
using TechDeviShopVs002.Models.ViewModel;

namespace TechDeviShopVs002.DAL
{
    public class ProductDAL
    {
        TechDeviShopDBContext db = null;

        public ProductDAL()
        {
            db = new TechDeviShopDBContext();
        }
        
        public List<Product> ListALl()
        {
            return db.Products.Where(x => x.IsActive == true).ToList();
        }

        public List<Product> ListALlVsNotActive()
        {
            return db.Products.ToList();
        }

        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public Product GetByProductName(string _productName)
        {
            return db.Products.SingleOrDefault(x => x.ProductName == _productName);
        }

        public List<Product> ListCateID(int id)
        {
            return db.Products.Where(x => x.CategoryID == id && x.IsActive == true).ToList();
        }

        public List<ProductViewModel> ListByCateID(int? _cateId, ref int totalRecord, int pageIndex = 1, int pageSize = 3)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == _cateId && x.IsActive == true).Count();
            var model = (from a in db.Products
                         join b in db.Categories
                         on a.CategoryID equals b.CategoryID
                         where a.CategoryID == _cateId && a.IsActive == true
                         select new
                         {
                             CateMetaTitle = b.MetaTitle,
                             CateName = b.CategoryName,
                             CreatedDate = a.CreateDate,
                             ID = a.ProductID,
                             Images = a.Image,
                             Name = a.ProductName,
                             MetaTitle = a.MetaTitle,
                             Price = a.Price,
                             PromotionPrice = a.PromotionPrice
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             CateMetaTitle = x.MetaTitle,
                             CateName = x.Name,
                             CreateDate = x.CreatedDate,
                             ProductID = x.ID,
                             Image = x.Images,
                             ProductName = x.Name,
                             MetaTitle = x.MetaTitle,
                             Price = x.Price,
                             PromotionPrice = x.PromotionPrice
                         });
            model.OrderByDescending(x => x.CreateDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }

        public int Insert(Product entity)
        {
            entity.CreateDate = DateTime.Now;
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ProductID;
        }

        public bool Update(Product entity)
        {
            try
            {
                var _product = db.Products.Find(entity.ProductID);
                _product.ProductName = entity.ProductName;
                _product.ProductCode = entity.ProductCode;
                _product.MetaTitle = entity.MetaTitle;
                _product.Description = entity.Description;
                _product.Image = entity.Image;
                _product.MoreImage = entity.MoreImage;
                _product.Price = entity.Price;
                _product.PromotionPrice = entity.PromotionPrice;
                _product.IncludeVAT = entity.IncludeVAT;
                _product.Quantity = entity.Quantity;
                _product.SupplierID = entity.SupplierID;
                _product.CategoryID = entity.CategoryID;
                _product.Warranty = entity.Warranty;
                _product.ModifiedDate = DateTime.Now;
                _product.ModifiedUser = entity.ModifiedUser;
                _product.CreateDate = entity.CreateDate;
                _product.CreateUser = entity.CreateUser;
                _product.MetalKeywords = entity.MetalKeywords;
                _product.MetalDescriptions = entity.MetalDescriptions;
                _product.IsActive = entity.IsActive;
                _product.TopHot = entity.TopHot;
                _product.ViewCount = entity.ViewCount;
                _product.CpuChip = entity.CpuChip;
                _product.CpuType = entity.CpuType;
                _product.CpuSpeed = entity.CpuSpeed;
                _product.CpuMaxSpeed = entity.CpuMaxSpeed;
                _product.BusSpeed = entity.BusSpeed;
                _product.Ram = entity.Ram;
                _product.RamType = entity.RamType;
                _product.BusRamSpeed = entity.BusRamSpeed;
                _product.MaxRam = entity.MaxRam;
                _product.HardDrive = entity.HardDrive;
                _product.Size = entity.Size;
                _product.Weight = entity.Weight;
                _product.Color = entity.Color;
                _product.Material = entity.Material;
                _product.ScreenSize = entity.ScreenSize;
                _product.Resolution = entity.Resolution;
                _product.ScreenTechnology = entity.ScreenTechnology;
                _product.TouchScreen = entity.TouchScreen;
                _product.GraphicsCard = entity.GraphicsCard;
                _product.Sound = entity.Sound;
                _product.ConnectionPort = entity.ConnectionPort;
                _product.WirelessConnection = entity.WirelessConnection;
                _product.MemoryCardSlot = entity.MemoryCardSlot;
                _product.OpticalDiskDrive = entity.OpticalDiskDrive;
                _product.Webcam = entity.Webcam;
                _product.KeyboardLights = entity.KeyboardLights;
                _product.PinType = entity.PinType;
                _product.Pin = entity.Pin;
                _product.OperatingSystem = entity.OperatingSystem;
                _product.OtherInfo = entity.OtherInfo;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Product ViewDetail(int? id)
        {
            return db.Products.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _product = db.Products.Find(id);
                db.Products.Remove(_product);
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
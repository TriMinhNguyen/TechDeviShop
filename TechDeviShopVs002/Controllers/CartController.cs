using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechDeviShopVs002.Models;
using TechDeviShopVs002.DAL;
using System.Web.Script.Serialization;
using System.Configuration;
using TechDeviShopVs002.Models.ViewModel;
using Common;
using TechDeviShopVs002.Common;

namespace TechDeviShopVs002.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var CusUserSession = (CusUserLogin)Session[CommonConstants.CusUserSession];
            if(CusUserSession != null)
            {
                var list = new List<CartItem>();
                var _sc = new ShoppingCartDAL().FindByCus(CusUserSession.CustomerID);
                if (_sc != null)
                {
                    int scid = _sc.ShoppingCartID;
                    var listSCD = new ShoppingCartDetailDAL().ListByShoppingCartID(scid).ToList();
                    if (listSCD != null)
                    {
                        foreach (var item in listSCD)
                        {
                            CartItem cIt = new CartItem();
                            cIt.ShoppingCartID = item.ShoppingCartID;
                            cIt.ShoppingCartDetailID = item.ShoppingCartDetailID;
                            cIt.Product = item.Product;
                            cIt.Quantity = (int)item.Quantity;
                            list.Add((CartItem)cIt);
                        }
                    }
                }
                return View(list);
            }
            else
            {
                var list = new List<CartItem>();
                if (cart != null)
                {
                    list = (List<CartItem>)cart;
                }
                return View(list);
            }
        }

        public JsonResult DeleteAll()
        {
            var CusUserSession = (CusUserLogin)Session[CommonConstants.CusUserSession];

            if (CusUserSession != null)
            {
                var _sc = new ShoppingCartDAL().FindByCus(CusUserSession.CustomerID);
                if (_sc != null)
                {
                    var listSCDetail = new ShoppingCartDetailDAL().ListByShoppingCartID(_sc.ShoppingCartID);
                    foreach (var item in listSCDetail)
                    {
                        new ShoppingCartDetailDAL().Delete(item.ShoppingCartDetailID);
                    }
                    new ShoppingCartDAL().Delete(_sc.ShoppingCartID);
                }
            }
            else if (CusUserSession == null)
            {
                Session[CartSession] = null;
            }
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var CusUserSession = (CusUserLogin)Session[CommonConstants.CusUserSession];

            if (CusUserSession != null)
            {
                var _sc = new ShoppingCartDAL().FindByCus(CusUserSession.CustomerID);
                if (_sc != null)
                {
                    var scDetail = new ShoppingCartDetailDAL().FindByProductID(_sc.ShoppingCartID, id);
                    new ShoppingCartDetailDAL().Delete(scDetail.ShoppingCartDetailID);
                }
            }
            else if (CusUserSession == null)
            {
                var sessionCart = (List<CartItem>)Session[CartSession];
                sessionCart.RemoveAll(x => x.Product.ProductID == id);
                Session[CartSession] = sessionCart;
            }
            
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var CusUserSession = (CusUserLogin)Session[CommonConstants.CusUserSession];
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);

            if (CusUserSession != null)
            {
                var _sc = new ShoppingCartDAL().FindByCus(CusUserSession.CustomerID);
                if (_sc != null)
                {
                    var _dal = new ShoppingCartDetailDAL();
                    var listSCDetail = new ShoppingCartDetailDAL().ListByShoppingCartID(_sc.ShoppingCartID);
                    foreach(var item in listSCDetail)
                    {
                        var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ProductID == item.Product.ProductID);
                        if (jsonItem != null)
                        {
                            item.Quantity = jsonItem.Quantity;
                        }
                        var _result = _dal.Update(item);
                    }
                }
            }
            else if(CusUserSession == null)
            {
                var sessionCart = (List<CartItem>)Session[CartSession];
                foreach (var item in sessionCart)
                {
                    var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ProductID == item.Product.ProductID);
                    if (jsonItem != null)
                    {
                        item.Quantity = jsonItem.Quantity;
                    }
                }
                Session[CartSession] = sessionCart;
            }
            
            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddItem(int productId, int quantity)
        {
            var CusUserSession = (CusUserLogin)Session[CommonConstants.CusUserSession];
            var product = new ProductDAL().ViewDetail(productId);
            var cart = Session[CartSession];

            if (CusUserSession == null)
            {
                if (cart != null)
                {
                    var list = (List<CartItem>)cart;
                    if (list.Exists(x => x.Product.ProductID == productId))
                    {

                        foreach (var item in list)
                        {
                            if (item.Product.ProductID == productId)
                            {
                                item.Quantity += quantity;
                            }
                        }
                    }
                    else
                    {
                        //tạo mới đối tượng cart item
                        var item = new CartItem();
                        item.Product = product;
                        item.Quantity = quantity;
                        list.Add(item);
                    }
                    //Gán vào session
                    Session[CartSession] = list;
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    var list = new List<CartItem>();
                    list.Add(item);
                    //Gán vào session
                    Session[CartSession] = list;
                }
            }
            else if(CusUserSession != null) //cusUserSession != null;
            {
                var _sc = new ShoppingCartDAL().FindByCus(CusUserSession.CustomerID);
                if (_sc != null)
                {
                    int _scID = _sc.ShoppingCartID;
                    //var list = (List<CartItem>)cart;
                    
                    var _dal = new ShoppingCartDetailDAL();
                    
                    //foreach (var item in list)
                    //{
                    //    _scID = item.ShoppingCartID;
                    //}
                    //if (list.Exists(x => x.Product.ProductID == productId))
                    //{
                    //    foreach (var item in list)
                    //    {
                    //        if (item.Product.ProductID == productId)
                    //        {
                    //            item.Quantity += quantity;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    //tạo mới đối tượng cart item
                    //    var item = new CartItem();
                    //    item.Product = product;
                    //    item.Quantity = quantity;
                    //    item.ShoppingCartID = _scID;
                    //    list.Add(item);
                    //}
                    var listSCDetail = new ShoppingCartDetailDAL().ListByShoppingCartID(_scID);
                    if (listSCDetail.Exists(x => x.Product.ProductID == productId))
                    {
                        foreach (var item in listSCDetail)
                        {
                            if (item.Product.ProductID == productId)
                            {
                                item.Quantity += quantity;
                            }
                            var _result = _dal.Update(item);
                        }
                    }
                    else
                    {
                        //tạo mới shopping cartdetail
                        var scDetailitem = new ShoppingCartDetail();
                        scDetailitem.ShoppingCartID = _scID;
                        scDetailitem.ProductID = product.ProductID;
                        scDetailitem.ProductName = product.ProductName;
                        scDetailitem.Quantity = quantity;
                        scDetailitem.UnitPrice = product.Price;
                        scDetailitem.PromotionPrice = product.PromotionPrice;
                        var _result = _dal.Insert(scDetailitem);
                    }
                    ////Gán vào session
                    //Session[CartSession] = list;
                }
                else if(_sc == null)//cart == null
                {
                    //tạo mới giỏ hàng, giỏ hàng chi tiết;
                    var _shoppingCart = new ShoppingCart();
                    _shoppingCart.ShoppingDate = DateTime.Now;
                    _shoppingCart.CustomerID = CusUserSession.CustomerID;
                    _shoppingCart.CreateUser = CusUserSession.CustomerID;
                    _shoppingCart.IsActive = true;
                    var _scart = new ShoppingCartDAL().Insert(_shoppingCart);

                    var _shoppingCartDetail = new ShoppingCartDetail();
                    _shoppingCartDetail.ShoppingCartID = _scart;
                    _shoppingCartDetail.ProductID = product.ProductID;
                    _shoppingCartDetail.ProductName = product.ProductName;
                    _shoppingCartDetail.Quantity = quantity;
                    _shoppingCartDetail.UnitPrice = product.Price;
                    _shoppingCartDetail.PromotionPrice = product.PromotionPrice;
                    var _scartDetail = new ShoppingCartDetailDAL().Insert(_shoppingCartDetail);

                    ////tạo mới đối tượng cart item
                    //var item = new CartItem();
                    //item.Product = product;
                    //item.Quantity = quantity;
                    //item.ShoppingCartID = _shoppingCart.ShoppingCartID;
                    //var list = new List<CartItem>();
                    //list.Add(item);
                    ////Gán vào session
                    //Session[CartSession] = list;
                }
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var CusUserSession = (CusUserLogin)Session[CommonConstants.CusUserSession];
            if (CusUserSession != null)
            {
                var list = new List<CartItem>();
                var _sc = new ShoppingCartDAL().FindByCus(CusUserSession.CustomerID);
                if (_sc != null)
                {
                    int scid = _sc.ShoppingCartID;
                    var listSCD = new ShoppingCartDetailDAL().ListByShoppingCartID(scid).ToList();
                    if (listSCD != null)
                    {
                        foreach (var item in listSCD)
                        {
                            CartItem cIt = new CartItem();
                            cIt.ShoppingCartID = item.ShoppingCartID;
                            cIt.ShoppingCartDetailID = item.ShoppingCartDetailID;
                            cIt.Product = item.Product;
                            cIt.Quantity = (int)item.Quantity;
                            list.Add((CartItem)cIt);
                        }
                    }
                }
                return View(list);
            }
            else
            {
                var list = new List<CartItem>();
                if (cart != null)
                {
                    list = (List<CartItem>)cart;
                }
                return View(list);
            }
        }

        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string address, string email)
        {
            var CusUserSession = (CusUserLogin)Session[TechDeviShopVs002.Common.CommonConstants.CusUserSession];
            var _sc = new ShoppingCartDAL().FindByCus(CusUserSession.CustomerID);

            var order = new Order();
            order.CustomerID = CusUserSession.CustomerID;
            order.OrderDate = DateTime.Now;
            order.Address = address;
            order.CusPhone = mobile;
            order.CusName = shipName;
            order.CusEmail = email;
            order.ShipperID = 1;
            order.ShippingMethodID = 2;
            order.OrderStatusID = 1;
            order.IsActive = true;
            
            try
            {
                var id = new OrderDAL().Insert(order);
                //var cart = (List<CartItem>)Session[CartSession];

                int scid = _sc.ShoppingCartID;
                var listSCD = new ShoppingCartDetailDAL().ListByShoppingCartID(scid).ToList();

                decimal total = 0;
                foreach (var item in listSCD)
                {
                    //Create order detail;
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.Product.ProductID;
                    orderDetail.OrderID = id;
                    orderDetail.ProductName = item.Product.ProductName;
                    orderDetail.ProductCode = item.Product.ProductCode;
                    orderDetail.UnitPrice = item.Product.Price;
                    orderDetail.PromotionPrice = item.Product.PromotionPrice;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.IsActive = true;
                    var detailDal = new OrderDetailsDAL().Insert(orderDetail);
                    

                    //End Shopping Cart
                    var spcart = new ShoppingCartDAL().ViewDetail(item.ShoppingCartID);
                    spcart.ExpireDate = DateTime.Now;
                    var spcartResult = new ShoppingCartDAL().Update(spcart);

                    //calculated total price;
                    total += (item.Product.Price.GetValueOrDefault(0) * (int)item.Quantity);
                }

                
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Client/template/neworder.html"));

                content = content.Replace("{{CustomerName}}", shipName);
                content = content.Replace("{{Phone}}", mobile);
                content = content.Replace("{{Email}}", email);
                content = content.Replace("{{Address}}", address);
                content = content.Replace("{{Total}}", total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(email, "Đơn hàng mới từ OnlineShop", content);
                new MailHelper().SendMail(toEmail, "Đơn hàng mới từ OnlineShop", content);
            }
            catch (Exception)
            {
                //ghi log
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("/hoan-thanh");
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult PaymentError()
        {
            return View();
        }
    }
}
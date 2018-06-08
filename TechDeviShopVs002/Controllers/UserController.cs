using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechDeviShopVs002.Common;
using TechDeviShopVs002.DAL;
using TechDeviShopVs002.Models;
using TechDeviShopVs002.Models.ViewModel;
using BotDetect.Web.UI.Mvc;
using Facebook;
using System.Configuration;
using System.Xml.Linq;

namespace TechDeviShopVs002.Controllers
{
    public class UserController : Controller
    {
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });


            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                // Get the user's information, like email, first name, middle name etc
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = me.email;
                string userName = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;

                var _cus = new Customer();
                _cus.CustomerEmail = email;
                _cus.IsActive = true;
                _cus.CustomerName = firstname + " " + middlename + " " + lastname;
                var resultInsert = new CustomerDAL().InsertForFacebook(_cus);
                if (resultInsert > 0)
                {
                    var cusUserSession = new CusUserLogin();
                    cusUserSession.CustomerEmail = _cus.CustomerEmail;
                    cusUserSession.CustomerName = _cus.CustomerName;
                    cusUserSession.CustomerID = _cus.CustomerID;
                    Session.Add(CommonConstants.CusUserSession, cusUserSession);
                }
            }
            return Redirect("/");
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.CusUserSession] = null;
            return Redirect("/");
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dal = new CustomerDAL();
                var result = dal.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var _cusUser = dal.GetByEmail(model.UserName);
                    var cusUserSession = new CusUserLogin();
                    cusUserSession.CustomerEmail = _cusUser.CustomerEmail;
                    cusUserSession.CustomerName = _cusUser.CustomerName;
                    cusUserSession.CustomerID = _cusUser.CustomerID;
                    Session.Add(CommonConstants.CusUserSession, cusUserSession);
                    return Redirect("/");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng.");
                }
            }
            return View(model);
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "registerCapcha", "Mã xác nhận không đúng!")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dal = new CustomerDAL();
                if (dal.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var _cusUser = new Customer();
                    _cusUser.CustomerName = model.Name;
                    _cusUser.Password = Encryptor.MD5Hash(model.Password);
                    _cusUser.CustomerPhone = model.Phone;
                    _cusUser.CustomerEmail = model.Email;
                    _cusUser.CustomerAddress = model.Address;
                    _cusUser.CustomerGender = model.Gender;
                    _cusUser.CustomerBirthday = model.Birthday;
                    _cusUser.IsActive = true;
                    if (!string.IsNullOrEmpty(model.ProvinceID))
                    {
                        //_cusUser.CustomerCity = int.Parse(model.ProvinceID);
                        _cusUser.CustomerCity = model.ProvinceID;
                    }
                    if (!string.IsNullOrEmpty(model.DistrictID))
                    {
                        //_cusUser.CustomerDistrict = int.Parse(model.DistrictID);
                        _cusUser.CustomerDistrict = model.DistrictID;
                    }

                    var result = dal.Insert(_cusUser);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                }
            }
            return View(model);
        }

        public JsonResult LoadProvince()
        {
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/Assets/Client/Data/Provinces_Data.xml"));

            var xElements = xmlDoc.Element("Root").Elements("Item").Where(x => x.Attribute("type").Value == "province");
            var list = new List<ProvinceModel>();
            ProvinceModel province = null;
            foreach (var item in xElements)
            {
                province = new ProvinceModel();
                province.ID = int.Parse(item.Attribute("id").Value);
                province.Name = item.Attribute("value").Value;
                list.Add(province);

            }
            return Json(new
            {
                data = list,
                status = true
            });
        }

        public JsonResult LoadDistrict(int provinceID)
        {
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/Assets/Client/Data/Provinces_Data.xml"));

            var xElement = xmlDoc.Element("Root").Elements("Item")
                .Single(x => x.Attribute("type").Value == "province" && int.Parse(x.Attribute("id").Value) == provinceID);

            var list = new List<DistrictModel>();
            DistrictModel district = null;
            foreach (var item in xElement.Elements("Item").Where(x => x.Attribute("type").Value == "district"))
            {
                district = new DistrictModel();
                district.ID = int.Parse(item.Attribute("id").Value);
                district.Name = item.Attribute("value").Value;
                district.ProvinceID = int.Parse(xElement.Attribute("id").Value);
                list.Add(district);

            }
            return Json(new
            {
                data = list,
                status = true
            });
        }


    }
}
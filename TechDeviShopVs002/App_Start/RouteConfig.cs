using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TechDeviShopVs002
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });
            
            routes.MapRoute(
                name: "About",
                url: "gioi-thieu",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Product Category",
                url: "sanpham/{metatitle}-{Cateid}",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Product",
                url: "product-find-by-{cateName}",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Product Detail",
                url: "chi-tiet/{metatitle}-{id}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Article",
                url: "tin-tuc",
                defaults: new { controller = "Article", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Article By Cate",
                url: "tin-tuc/{metatitle}-{id}",
                defaults: new { controller = "Article", action = "ArticleByCate", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Article Category",
                url: "tin-tuc/{metatitle}-{id}",
                defaults: new { controller = "Article", action = "ArticleCategory", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Article Detail",
                url: "tin-tuc/chi-tiet/{metatitle}-{id}",
                defaults: new { controller = "Article", action = "Details", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Cart",
                url: "gio-hang",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Add Cart",
                url: "them-gio-hang",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Payment",
                url: "thanh-toan",
                defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Payment Success",
                url: "hoan-thanh",
                defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Payment Error",
                url: "loi-thanh-toan",
                defaults: new { controller = "Cart", action = "PaymentError", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Register",
                url: "dang-ky",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Profile",
                url: "ho-so",
                defaults: new { controller = "Profile", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Profile change pass",
                url: "ho-so/changepass",
                defaults: new { controller = "Profile", action = "ChangePass", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Profile Order History",
                url: "ho-so/history-order-detail-{id}",
                defaults: new { controller = "Profile", action = "HistoryOrderDetail", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Profile Order Ongoing",
                url: "ho-so/ongoing-order-detail-{id}",
                defaults: new { controller = "Profile", action = "OngoingOrderDetail", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Cancel order Success",
                url: "huy-bo-thanh-cong",
                defaults: new { controller = "Profile", action = "CancelOrderSuccess", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Cancel order Error",
                url: "loi-huy-bo",
                defaults: new { controller = "Profile", action = "CancelOrderError", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TechDeviShopVs002.Controllers" }
            );
        }
    }
}

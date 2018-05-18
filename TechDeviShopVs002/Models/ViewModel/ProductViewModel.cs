using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechDeviShopVs002.Models.ViewModel
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string Image { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public string MetaTitle { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CateName { get; set; }
        public string CateMetaTitle { get; set; }

    }
}
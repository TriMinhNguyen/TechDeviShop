using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechDeviShopVs002.Common
{
    [Serializable]
    public class CusUserLogin
    {
        public int CustomerID { set; get; }
        public string CustomerName { set; get; }
        public string CustomerEmail { get; set; }
    }
}
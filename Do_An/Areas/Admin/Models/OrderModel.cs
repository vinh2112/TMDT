using Do_An.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An.Areas.Admin.Models
{
    public class OrderModel
    {
        MainDbContext db = null;
        public OrderModel()
        {
            db = new MainDbContext();
        }
        public string countOrder()
        {
            return db.DONHANGs.Count().ToString();
        }
    }
}
using Do_An.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An.Areas.Admin.Models
{
    public class CustomerModel
    {
        MainDbContext db = null;
        public CustomerModel()
        {
            db = new MainDbContext();
        }
        public IEnumerable<INFORMATION> ListAllCustomer()
        {
            return db.INFORMATION;
        }
        public string countCustomer()
        {
            return db.INFORMATION.Count().ToString();
        }
    }
}
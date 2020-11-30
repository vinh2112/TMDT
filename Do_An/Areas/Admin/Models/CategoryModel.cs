using Do_An.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An.Areas.Admin.Models
{
    public class CategoryModel
    {
        MainDbContext db = null;
        public CategoryModel()
        {
            db = new MainDbContext();
        }
        public IEnumerable<DANHMUC> ListAllCategory()
        {
            return db.DANHMUCs.OrderBy(x => x.MaDM);
        }
    }
}
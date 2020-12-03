using Do_An.Frameworks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            return db.DONHANGs.Where(x => x.TinhTrang == "Đang chờ").Count().ToString();
        }
        public IEnumerable<DONHANG> ListOrderbySDT(string SDT)
        {
            return db.DONHANGs.Where(x => x.SDT == SDT).OrderBy(x => x.MaDH);
        }
        public IEnumerable<DONHANG> ListAllOrder()
        {
            return db.DONHANGs.OrderBy(x => x.MaDH);
        }
        public IEnumerable<DONHANG> ListAllWaitingOrder()
        {
            return db.DONHANGs.Where(x => x.TinhTrang == "Đang chờ").OrderBy(x => x.MaDH);
        }
        public IEnumerable<DH_SP> infoDonHang(string MaDH)
        {
            return db.DH_SP.Where(x => x.MaDH == MaDH);
        }
        public bool cancelOrder(string MaDH)
        {
            object sqlparam = new SqlParameter("@MaDH", MaDH);
            try
            {
                db.Database.ExecuteSqlCommand("huyDONHANG @MaDH", sqlparam);
                return true;
            }
            catch { }
            return false;
        }
        public bool verifyOrder(string MaDH, int TongTien)
        {
            object[] sqlparams =
            {
                new SqlParameter("@MaDH", MaDH),
                new SqlParameter("@TongTien", TongTien)
            };
            try
            {
                db.Database.ExecuteSqlCommand("verifyDONHANG @MaDH, @TongTien", sqlparams);
                return true;
            }
            catch { }
            return false;
        }

    }
}
using Do_An.Frameworks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Do_An.Areas.Customer.Models
{
    public class CartModel
    {
        MainDbContext db = null;
        public static string cn = @"Data Source=DESKTOP-LABJ7FR;Initial Catalog=TMDT;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection conn = new SqlConnection(cn);
        public CartModel()
        {
            db = new MainDbContext();
        }
        public List<GIOHANG> XemGioHang(string sdt)
        {
            List<GIOHANG> cd = new List<GIOHANG>();
            SqlCommand text = new SqlCommand("Select * From GIOHANG Where SDT='" + sdt + "'", conn);
            conn.Open();
            SqlDataReader data = text.ExecuteReader();
            while (data.Read())
            {
            }
            conn.Close();
            return cd;
        }
        public void XoaSanPham(string sdt, string maSP)
        {
            SqlCommand cmd = new SqlCommand("Delete From GIOHANG Where SDT='" + sdt + "' and MaSP='" + maSP + "'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void SuaSoLuong(int stt, int soluong)
        {
            SqlCommand cmd = new SqlCommand("Update GIOHANG SET SoLuong=" + soluong + " Where STT='" + stt + "'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void XoaHet(string sdt)
        {
            SqlCommand cmd = new SqlCommand("Delete From GIOHANG Where SDT='" + sdt + "'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void ThemGioHang(string sdt, string maSP, int soluong)
        {
            SqlCommand cmd = new SqlCommand("Insert into GIOHANG(SDT,MaSP,SoLuong) VALUES(" + sdt + "," + maSP + "," + soluong + ")", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
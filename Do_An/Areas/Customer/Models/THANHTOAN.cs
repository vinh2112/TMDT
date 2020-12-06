using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Do_An.Areas.Customer.Models
{
    public class THANHTOAN
    {
        Connection cn = new Connection();
        SqlConnection conn = new SqlConnection("Data Source = MINHDINH; Initial Catalog = TMDT; Integrated Security = True; MultipleActiveResultSets=True;Application Name = EntityFramework");
        public int STT { get; set; }
        [Key]
        [StringLength(10)]
        public String SDT { get; set; }

        [StringLength(50)]
        public string MaSP { get; set; }

        public int? SoLuong { get; set; }
        public int? Gia { get; set; }

        [StringLength(100)]
        public string TenKH { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }
        [StringLength(200)]
        public string ChuThich { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        //public int thanhtoan { get { return (int)Gia * (int)SoLuong; } }
        public string PhuongThucTT { get; set; }




        public string TaoMaDH()
        {
            string UpperCase = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string Digits = "1234567890";
            string allCharacters = UpperCase + Digits;
            string madh = "";
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                double rand = r.NextDouble();
                if (i == 0)
                {
                    madh += UpperCase.ToCharArray()[(int)Math.Floor(rand * UpperCase.Length)];
                }
                else
                {
                    madh += allCharacters.ToCharArray()[(int)Math.Floor(rand * allCharacters.Length)];
                }
            }
            return madh;
        }
        public void Mua_Update(string SDT, string DiaChi, string chuthich="không có")
        {
            //tạo mã đơn hàng tự động
            string madh = TaoMaDH();
            var item = from a in cn.DONHANGs where a.MaDH == madh select a;
            while (item.Count() != 0)
            {
                madh = TaoMaDH();
                item = from a in cn.DONHANGs where a.MaDH == madh select a;
            }

            //
            var prmt = new SqlParameter[]
                {
                             new SqlParameter("@MaDH", madh),
                             new SqlParameter("@SDT", SDT),
                             new SqlParameter("@DiaChi", DiaChi),
                             new SqlParameter("@TinhTrang", "Đang Chờ"),
                             new SqlParameter("@ChuThich", chuthich)
                };
            cn.DONHANGs.SqlQuery("ThemDONHANG @MaDH, @SDT, @DiaChi, @TinhTrang, @ChuThich", prmt).ToList();
            XoaSPDaMua(SDT);

        }
        public void XoaSPDaMua(string SDT)
        {
            //Xóa SP đã mua trong giỏ
            SqlParameter prm = new SqlParameter("@sdt", SDT);
            SqlCommand cmd = new SqlCommand("Delete From GIOHANG Where SDT=@sdt", conn);
            cmd.Parameters.Add(prm);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Update_DiaChi(string diachi, string sdt)
        {
            SqlParameter phone = new SqlParameter("@SDT", sdt);
            SqlParameter address = new SqlParameter("@DiaChi", diachi);
            SqlCommand cmd = new SqlCommand("Update INFORMATION set DiaChi=@DiaChi where SDT=@SDT",     conn);
            cmd.Parameters.Add(address);
            cmd.Parameters.Add(phone);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
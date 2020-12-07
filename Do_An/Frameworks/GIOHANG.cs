namespace Do_An.Frameworks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;

    [Table("GIOHANG")]
    public partial class GIOHANG
    {
        public static string cn = @"Data Source=DESKTOP-LABJ7FR;Initial Catalog=TMDT;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection conn = new SqlConnection(cn);
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int STT { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }
        [StringLength(50)]
        public string tenSP
        {
            get
            {
                string tensp = "";
                SqlCommand text = new SqlCommand("Select * From SANPHAM Where MaSP='" + MaSP + "'", conn);
                conn.Open();
                SqlDataReader data = text.ExecuteReader();
                while (data.Read())
                {
                    tensp = (string)data["TenSP"] + " " + (string)data["MauSac"] + " " + (string)data["KichThuoc"];
                }
                conn.Close();
                return tensp;
            }
        }

        [StringLength(50)]
        public string MaSP { get; set; }

        public int? SoLuong { get; set; }
        public int DonGia
        {
            get
            {
                int dongia = 0;
                SqlCommand text = new SqlCommand("Select Gia From SANPHAM Where MaSP='" + MaSP + "'", conn);
                conn.Open();
                SqlDataReader data = text.ExecuteReader();
                while (data.Read())
                {
                    dongia = (int)data["Gia"];
                }
                conn.Close();
                return dongia;

            }
        }
        public string SPimg
        {
            get
            {
                string Hinh = "";
                SqlCommand text = new SqlCommand("Select HinhAnh From SANPHAM Where MaSP='" + MaSP + "'", conn);
                conn.Open();
                SqlDataReader data = text.ExecuteReader();
                while (data.Read())
                {
                    Hinh = (string)data["HinhAnh"];
                }
                conn.Close();
                return Hinh;

            }

        }

        public float ThanhTien
        {
            get
            {
                return DonGia * (float)SoLuong;
            }
        }

        public virtual SANPHAM SANPHAM { get; set; }

        public virtual INFORMATION INFORMATION { get; set; }
    }
}

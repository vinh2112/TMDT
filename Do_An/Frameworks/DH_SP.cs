namespace Do_An.Frameworks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DH_SP
    {
        MainDbContext db = new MainDbContext();
        [StringLength(50)]
        public string MaDH { get; set; }

        [StringLength(50)]
        public string MaSP { get; set; }
        public string TenSP
        {
            get
            {
                string tenSP = "";
                tenSP = db.SANPHAMs.Find(MaSP).TenSP.ToString();
                return tenSP;
            }
        }

        public int Gia
        {
            get
            {
                int Gia = 0;
                Gia += Convert.ToInt32(db.SANPHAMs.Find(MaSP).Gia.ToString()) * Convert.ToInt32(SoLuong);
                return Gia;
            }
        }

        public int? SoLuong { get; set; }

        [Key]
        public int STT { get; set; }

        public virtual DONHANG DONHANG { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}

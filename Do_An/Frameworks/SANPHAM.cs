namespace Do_An.Frameworks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            GIOHANGs = new HashSet<GIOHANG>();
        }

        [Key]
        [StringLength(50)]
        public string MaSP { get; set; }

        [StringLength(200)]
        public string TenSP { get; set; }

        [StringLength(50)]
        public string MauSac { get; set; }

        [StringLength(50)]
        public string KichThuoc { get; set; }

        public int? Gia { get; set; }

        [StringLength(50)]
        public string MaTH { get; set; }

        [StringLength(100)]
        public string NoiSX { get; set; }

        [StringLength(200)]
        public string HinhAnh { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(50)]
        public string MaDM { get; set; }

        public virtual BRAND BRAND { get; set; }

        public virtual DANHMUC DANHMUC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIOHANG> GIOHANGs { get; set; }
    }
}

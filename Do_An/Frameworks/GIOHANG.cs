namespace Do_An.Frameworks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIOHANG")]
    public partial class GIOHANG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int STT { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string MaSP { get; set; }

        public int? SoLuong { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }

        public virtual INFORMATION INFORMATION { get; set; }
    }
}

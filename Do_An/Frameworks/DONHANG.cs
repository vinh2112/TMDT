namespace Do_An.Frameworks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONHANG")]
    public partial class DONHANG
    {
        [Key]
        [StringLength(50)]
        public string MaDH { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        public DateTime? NgayThang { get; set; }

        [StringLength(50)]
        public string TinhTrang { get; set; }

        public virtual INFORMATION INFORMATION { get; set; }
    }
}

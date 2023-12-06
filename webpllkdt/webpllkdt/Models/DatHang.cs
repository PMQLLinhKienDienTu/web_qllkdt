namespace webpllkdt.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatHang")]
    public partial class DatHang
    {
        [Key]
        public int MaDatHang { get; set; }

        public int? MaKhachHang { get; set; }

        public int? SoLuongDat { get; set; }

        public double? TongTien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDat { get; set; }

        public bool? TrangThai { get; set; }

        public string JsonSanPham { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}

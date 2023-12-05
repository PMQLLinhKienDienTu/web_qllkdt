namespace webpllkdt.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietNhapHang")]
    public partial class ChiTietNhapHang
    {
        [Key]
        public int MaNhap { get; set; }

        public int MaSanPham { get; set; }

        public int? SoLuongNhap { get; set; }

        public double GiaNhap { get; set; }

        public int? MaNhapHang { get; set; }

        public virtual NhapHang NhapHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}

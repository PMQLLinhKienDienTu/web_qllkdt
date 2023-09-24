namespace webpllkdt.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [Key]
        public int MaChiTietHoaDon { get; set; }

        public int Soluong { get; set; }

        public double Gia { get; set; }

        public int MaSp { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}

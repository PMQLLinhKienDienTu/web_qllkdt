namespace webpllkdt.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            ChiTietNhapHangs = new HashSet<ChiTietNhapHang>();
        }

        [Key]
        public int MaSP { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        public int? SoLuong { get; set; }

        public double? GiaNhap { get; set; }

        public double? GiaBan { get; set; }

        public int? TGBaoHanh { get; set; }

        public int? MaPhanLoai { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [Column(TypeName = "image")]
        public byte[] HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNhapHang> ChiTietNhapHangs { get; set; }

        public virtual PhanLoaiSanPham PhanLoaiSanPham { get; set; }
    }
}

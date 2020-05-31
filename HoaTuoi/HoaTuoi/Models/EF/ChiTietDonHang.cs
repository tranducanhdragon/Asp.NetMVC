namespace HoaTuoi.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDChiTietDonHang { get; set; }

        public int SoLuongHoa { get; set; }

        public int? ThanhTien { get; set; }

        public DateTime? NgayTao { get; set; }

        [StringLength(50)]
        public string TenNguoiDung { get; set; }

        public int? DienThoai { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        public int? IDDonHang { get; set; }

        public virtual DonHang DonHang { get; set; }
    }
}

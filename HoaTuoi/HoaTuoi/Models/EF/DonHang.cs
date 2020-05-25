namespace HoaTuoi.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDDonHang { get; set; }

        public int IDNguoiDung { get; set; }

        public int? IDGioHang { get; set; }

        public int? IDChiTietDonHang { get; set; }

        public virtual ChiTietDonHang ChiTietDonHang { get; set; }

        public virtual GioHang GioHang { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}

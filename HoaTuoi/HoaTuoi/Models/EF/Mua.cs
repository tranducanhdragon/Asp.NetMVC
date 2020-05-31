namespace HoaTuoi.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mua")]
    public partial class Mua
    {
        public int? IDGioHang { get; set; }

        public int? IDHoa { get; set; }

        public int? SoLuong { get; set; }

        [Key]
        public int IDMua { get; set; }

        public virtual GioHang GioHang { get; set; }

        public virtual Hoa Hoa { get; set; }
    }
}

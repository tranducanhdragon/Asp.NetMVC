namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SachView")]
    public partial class SachView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSach { get; set; }

        [StringLength(50)]
        public string TenSach { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(50)]
        public string TenTheLoai { get; set; }

        [StringLength(50)]
        public string TenNXB { get; set; }

        [StringLength(100)]
        public string AnhDaiDien { get; set; }
    }
}

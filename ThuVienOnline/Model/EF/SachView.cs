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
        [Required]
        [Display(Name = "Tên Sách")]
        public string TenSach { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name ="Tên Tác Giả")]
        public string HoTen { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Thể Loại")]
        public string TenTheLoai { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Nhà Xuất Bản")]
        public string TenNXB { get; set; }

        [StringLength(100)]
        [Display(Name = "Ảnh Bìa")]
        public string AnhDaiDien { get; set; }
    }
}

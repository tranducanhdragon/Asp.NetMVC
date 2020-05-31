namespace HoaTuoi.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hoa")]
    public partial class Hoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hoa()
        {
            Muas = new HashSet<Mua>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDHoa { get; set; }

        [Required]
        [StringLength(50)]
        public string TenHoa { get; set; }

        public int GiaTien { get; set; }

        [Required]
        [StringLength(100)]
        public string AnhDaiDien { get; set; }

        public int? IDDanhMuc { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mua> Muas { get; set; }
    }
}

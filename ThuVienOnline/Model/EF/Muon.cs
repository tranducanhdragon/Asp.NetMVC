namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Muon")]
    public partial class Muon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Muon()
        {
            Tras = new HashSet<Tra>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDMuon { get; set; }

        public int? IDThe { get; set; }

        public int? MaSach { get; set; }

        public int? SoLuongSach { get; set; }

        public virtual Sach Sach { get; set; }

        public virtual TheThuVien TheThuVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tra> Tras { get; set; }
    }
}

namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tra")]
    public partial class Tra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDTra { get; set; }

        public int? IDMuon { get; set; }

        public int? IDThe { get; set; }

        public virtual Muon Muon { get; set; }

        public virtual TheThuVien TheThuVien { get; set; }
    }
}

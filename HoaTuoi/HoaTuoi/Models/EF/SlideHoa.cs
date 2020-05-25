namespace HoaTuoi.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SlideHoa")]
    public partial class SlideHoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDSlide { get; set; }

        [StringLength(100)]
        public string AnhDaiDien { get; set; }
    }
}

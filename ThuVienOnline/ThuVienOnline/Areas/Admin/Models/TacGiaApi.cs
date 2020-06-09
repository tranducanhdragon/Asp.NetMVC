using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThuVienOnline.Areas.Admin.Models
{
    public partial class TacGiaApi
    {
        [Key]
        public int MaTG { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }
    }
}
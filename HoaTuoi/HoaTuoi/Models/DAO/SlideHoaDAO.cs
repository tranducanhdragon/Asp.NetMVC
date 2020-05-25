using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoaTuoi.Models.EF;

namespace HoaTuoi.Models.DAO
{
    public class SlideHoaDAO
    {
        HoaTuoiDBContext db = null;
        public SlideHoaDAO()
        {
            db = new HoaTuoiDBContext();
        }
        public List<SlideHoa> Slide()
        {
            return db.SlideHoas.OrderByDescending(x => x.IDSlide).ToList();
        }
    }
}
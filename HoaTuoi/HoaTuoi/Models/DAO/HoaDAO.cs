using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoaTuoi.Models.EF;

namespace HoaTuoi.Models.DAO
{
    public class HoaDAO
    {
        HoaTuoiDBContext db = null;
        public HoaDAO()
        {
            db = new HoaTuoiDBContext();
        }
        public List<Hoa> DanhSachHoa()
        {
            return db.Hoas.OrderBy(x => x.IDHoa).ToList();
        }
        public Hoa HoaByID(int id)
        {
            return db.Hoas.Find(id);
        }
    }
}
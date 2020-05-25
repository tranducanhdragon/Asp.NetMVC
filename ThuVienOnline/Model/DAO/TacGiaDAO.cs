using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using System.Data.SqlClient;

namespace Model.DAO
{
    public class TacGiaDAO
    {
        ThuVienOnlineDBContext db = null;
        public TacGiaDAO()
        {
            db = new ThuVienOnlineDBContext();
        }
        public IEnumerable<TacGia>ListAllPaging(int page, int pageSize)
        {
            return db.TacGias.OrderByDescending(x => x.MaTG).ToPagedList(page, pageSize);
        }
        public void Create(TacGia tg)
        {
            object para = new SqlParameter("@HoTen", tg.HoTen);
            var res = db.Database.ExecuteSqlCommand("TacGia_InsertProc @HoTen", para);
        }
        public void Delete(int id)
        {
            var tg = db.TacGias.Find(id);
            db.TacGias.Remove(tg);
            db.SaveChanges();
        }
        public IEnumerable<string> TenTG()
        {
            return db.TacGias.Select(model=>model.HoTen).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class TheLoaiDAO
    {
        ThuVienOnlineDBContext db = null;
        public TheLoaiDAO()
        {
            db = new ThuVienOnlineDBContext();
        }
        public long Insert(TheLoai entity)
        {
            //Lấy mã the loai đã có trong db + 1
            entity.MaTheLoai = db.TheLoais.ToList().Last().MaTheLoai + 1;
            db.TheLoais.Add(entity);
            db.SaveChanges();
            return entity.MaTheLoai;
        }
        public bool Update(TheLoai entity, int id)
        {
            try
            {
                var tl = db.TheLoais.Find(id);
                tl.TenTheLoai = entity.TenTheLoai;
                tl.AnhDaiDien = entity.AnhDaiDien;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                TheLoai tk = db.TheLoais.Find(id);
                db.TheLoais.Remove(tk);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //select * from TheLoai theo pagedList
        public IEnumerable<TheLoai> ListAllPaging(int page, int pageSize)
        {
            return db.TheLoais.OrderByDescending(x => x.MaTheLoai).ToPagedList(page, pageSize);
        }
        public TheLoai GetTheLoaiByID(int id)
        {
            return db.TheLoais.SingleOrDefault(tl=>tl.MaTheLoai == id);
        }
        public IEnumerable<string> TenTL()
        {
            return db.TheLoais.Select(x => x.TenTheLoai).ToList();
        }
    }
}

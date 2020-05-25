using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class NXBDAO
    {
        ThuVienOnlineDBContext db = null;
        public NXBDAO()
        {
            db = new ThuVienOnlineDBContext();
        }
        public long Insert(NXB entity)
        {
            //Lấy mã NXB đã có trong db + 1
            entity.MaNXB = db.NXBs.ToList().Last().MaNXB + 1;
            db.NXBs.Add(entity);
            db.SaveChanges();
            return entity.MaNXB;
        }
        public bool Update(NXB entity, int id)
        {
            try
            {
                var tl = db.NXBs.Find(id);
                tl.TenNXB = entity.TenNXB;
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
                NXB tk = db.NXBs.Find(id);
                db.NXBs.Remove(tk);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //select * from NXB theo pagedList
        public IEnumerable<NXB> ListAllPaging(int page, int pageSize)
        {
            return db.NXBs.OrderByDescending(x => x.MaNXB).ToPagedList(page, pageSize);
        }
        public NXB GetNXBByID(int id)
        {
            return db.NXBs.SingleOrDefault(tl => tl.MaNXB == id);
        }
        public IEnumerable<string> TenNXB()
        {
            return db.NXBs.Select(x => x.TenNXB).ToList();
        }
    }
}

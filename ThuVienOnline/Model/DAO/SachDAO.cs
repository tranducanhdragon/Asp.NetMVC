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
    public class SachDAO
    {
        ThuVienOnlineDBContext db = null;
        public SachDAO()
        {
            db = new ThuVienOnlineDBContext();
        }
        public bool Insert(SachView entity)
        {
            try
            {
                var para = new SqlParameter[]
                    {
                            new SqlParameter("@TenSach", entity.TenSach),
                            new SqlParameter("@TenTacGia", entity.HoTen),
                            new SqlParameter("@TenNXB", entity.TenNXB),
                            new SqlParameter("@TenTheLoai", entity.TenTheLoai),
                            new SqlParameter("@AnhDaiDien", entity.AnhDaiDien),
                    };
                db.Database.ExecuteSqlCommand("Sach_InsertProc @TenSach, @TenTacGia, @TenNXB, @TenTheLoai, @AnhDaiDien", para);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(SachView entity, int id)
        {
            try
            {
                var s = db.Saches.Find(id);
                s.TenSach = entity.TenSach;
                s.AnhDaiDien = entity.AnhDaiDien;
                s.MaTG = db.TacGias.SingleOrDefault(x => x.HoTen == entity.HoTen).MaTG;
                s.MaNXB = db.NXBs.SingleOrDefault(x => x.TenNXB == entity.TenNXB).MaNXB;
                s.MaTheLoai = db.TheLoais.SingleOrDefault(x => x.TenTheLoai == entity.TenTheLoai).MaTheLoai;
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
                Sach tk = db.Saches.Find(id);
                db.Saches.Remove(tk);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<SachView> SachListPaging(int page, int pageSize)
        {
            return db.SachViews.OrderByDescending(x => x.TenSach).ToPagedList(page, pageSize);
        }
        public IEnumerable<SachView> SachByDMPaging(int iddm, int page, int pageSize)
        {
            var tendm = db.TheLoais.SingleOrDefault(x => x.MaTheLoai == iddm).TenTheLoai;
            return db.SachViews.OrderByDescending(x => x.TenSach).Where(x => x.TenTheLoai == tendm).ToPagedList(page, pageSize);
        }
        public SachView GetSachByID(int id)
        {
            return db.SachViews.Find(id);
        }
    }
}

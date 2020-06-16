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
    public class TheThuVienDAO
    {
        ThuVienOnlineDBContext db = null;
        public TheThuVienDAO()
        {
            db = new ThuVienOnlineDBContext();
        }
        public void Insert(TheThuVien entity)
        {
            object[] para = new SqlParameter[]
            {
                new SqlParameter("@NgayTao", entity.NgayTao),
                new SqlParameter("@NgayHetHan", entity.NgayHetHan),
                new SqlParameter("@TrangThai", entity.TrangThai),
                new SqlParameter("@IDNhanVien", entity.IDNhanVien)
            };
            db.Database.ExecuteSqlCommand("TheThuVien_InsertProc @NgayTao, @NgayHetHan, @TrangThai, @IDNhanVien", para);
        }
        public bool Update(TheThuVien entity, int id)
        {
            try
            {
                var the = db.TheThuViens.Find(id);
                the.IDNhanVien = entity.IDNhanVien;
                the.NgayTao = entity.NgayTao;
                the.NgayHetHan = entity.NgayHetHan;
                the.TrangThai = entity.TrangThai;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ChangeTrangThai(int id)
        {
            var the = db.TheThuViens.Find(id);
            bool tt = the.TrangThai;
            the.TrangThai = !tt;
            db.SaveChanges();
            return the.TrangThai;
        }
        public void InsertMuon(int idThe, int idSach, int soluong)
        {
            var muon = new Muon();
            muon.IDThe = idThe;
            muon.MaSach = idSach;
            muon.SoLuongSach = soluong;
            db.Muons.Add(muon);
            db.SaveChanges();
        }
        public void DeleteMuon(int idThe, int idSach)
        {
            var muon = (from a in db.Muons
                        where a.IDThe == idThe && a.MaSach == idSach
                        select a).ToList();
            db.Muons.RemoveRange(muon);
            db.SaveChanges();
        }
        public bool Delete(int id)
        {
            try
            {
                TheThuVien tk = db.TheThuViens.Find(id);
                db.TheThuViens.Remove(tk);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //select * from TheThuVien theo pagedList
        public IEnumerable<TheThuVien> ListAllPaging(int page, int pageSize)
        {
            return db.TheThuViens.OrderByDescending(x => x.IDThe).ToPagedList(page, pageSize);
        }
        public TheThuVien GetTheThuVienByID(int id)
        {
            return db.TheThuViens.SingleOrDefault(tl => tl.IDThe == id);
        }
        //thông kê số lượng sách mượn theo mã thẻ và mã sách
        public IEnumerable<GroupMuon> MuonListAllPaging(int idthe, int page, int pageSize)
        {
            return db.Muons.GroupBy(x =>new { x.IDThe, x.MaSach}).Select(y=>new GroupMuon()
            {
                IDThe = y.Key.IDThe,
                MaSach = y.Key.MaSach,
                SoLuongSach = y.Sum(x=>x.SoLuongSach),
            }).OrderByDescending(x=>x.IDThe).Where(x=>x.IDThe == idthe).ToPagedList(1, 10);
        }
        public IEnumerable<Tra> TraListAllPaging(int idthe, int page, int pageSize)
        {
            return db.Tras.OrderByDescending(x => x.IDTra).Where(x => x.IDThe == idthe).ToPagedList(page, pageSize);
        }
    }
}

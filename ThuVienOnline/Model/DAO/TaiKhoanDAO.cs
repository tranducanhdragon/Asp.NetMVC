using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class TaiKhoanDAO
    {
        ThuVienOnlineDBContext db = null;
        public TaiKhoanDAO()
        {
            db = new ThuVienOnlineDBContext();
        }
        public long Insert(TaiKhoan entity)
        {
            //Lấy mã tk đã có trong db + 1
            entity.MaTaiKhoan = db.TaiKhoans.ToList().Last().MaTaiKhoan + 1;
            db.TaiKhoans.Add(entity);
            db.SaveChanges();
            return entity.MaTaiKhoan;
        }
        public bool Update(TaiKhoan entity, int id)
        {
            try
            {
                var user = db.TaiKhoans.Find(id);
                user.TenDangNhap = entity.TenDangNhap;
                user.MatKhau = entity.MatKhau;
                db.SaveChanges();
                return true;
            }
            catch(Exception) {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                TaiKhoan tk = db.TaiKhoans.Find(id);
                db.TaiKhoans.Remove(tk);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //select * from TaiKhoan theo pagedList
        public IEnumerable<TaiKhoan> ListAllPaging(int page, int pageSize)
        {
            return db.TaiKhoans.OrderByDescending(x => x.MaTaiKhoan).ToPagedList(page, pageSize);
        }
        public bool Login(string userName, string passWord)
        {
            var result = db.TaiKhoans.Count(x => x.TenDangNhap == userName && x.MatKhau == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Lấy tài khoản thông qua tên tài khoản
        public TaiKhoan GetByName(string userName)
        {
            return db.TaiKhoans.SingleOrDefault(x => x.TenDangNhap == userName);
        }
        public TaiKhoan GetByID(int ID)
        {
            return db.TaiKhoans.Find(ID);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoaTuoi.Models.EF;

namespace HoaTuoi.Models.DAO
{
    public class NguoiDungDAO
    {
        HoaTuoiDBContext db = null;
        public NguoiDungDAO()
        {
            db = new HoaTuoiDBContext();
        }
        public bool Login(string userName, string passWord)
        {
            var result = db.NguoiDungs.Count(x => x.TenDangNhap == userName && x.MatKhau == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void NguoiDungInsert(NguoiDung nguoidung)
        {
            nguoidung.IDNguoiDung = db.NguoiDungs.ToList().Last().IDNguoiDung + 1;
            db.NguoiDungs.Add(nguoidung);
            db.SaveChanges();
        }
        public NguoiDung NguoiDungByID(int id)
        {
            return db.NguoiDungs.SingleOrDefault(x => x.IDNguoiDung == id);
        }
        public NguoiDung NguoiDungByUserName(string userName)
        {
            return db.NguoiDungs.SingleOrDefault(x => x.TenDangNhap == userName);
        }
    }
}
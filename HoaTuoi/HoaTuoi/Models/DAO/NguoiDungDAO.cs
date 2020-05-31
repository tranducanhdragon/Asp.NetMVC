using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            object[] para = new SqlParameter[]
            {
                new SqlParameter("@TenNguoiDung",nguoidung.TenNguoiDung),
                new SqlParameter("@MatKhau",nguoidung.MatKhau),
                new SqlParameter("@TenDangNhap",nguoidung.TenDangNhap),
                new SqlParameter("@DiaChi",nguoidung.DiaChi),
                new SqlParameter("@DienThoai",nguoidung.DienThoai),
                new SqlParameter("@Email",nguoidung.Email),
                new SqlParameter("@Quyen",nguoidung.Quyen)
            };
            db.Database.ExecuteSqlCommand("NguoiDung_InsertProc @TenNguoiDung, @MatKhau, @TenDangNhap, @DiaChi, @DienThoai, @Email, @Quyen", para);
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
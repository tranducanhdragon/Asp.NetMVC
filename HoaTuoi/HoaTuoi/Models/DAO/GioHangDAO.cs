using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HoaTuoi.Models.EF;

namespace HoaTuoi.Models.DAO
{
    public class GioHangDAO
    {
        HoaTuoiDBContext db = null;
        public GioHangDAO()
        {
            db = new HoaTuoiDBContext();
        }
        
        public void GioHang_Insert(GioHang gh)
        {
            object[] para = new SqlParameter[]
            {
                new SqlParameter("@SoLuongHoa",gh.SoLuongHoa),
                new SqlParameter("@NgayTao",gh.NgayTao),
                new SqlParameter("@ThanhTien",gh.ThanhTien),
            };
            db.Database.ExecuteSqlCommand("GioHang_InsertProc @SoLuongHoa, @NgayTao, @ThanhTien", para);
        }
        public string GioHang_GetIDJustInsert()
        {
            var id = new SqlParameter();
            id.ParameterName = "IDGioHang";
            id.SqlDbType = SqlDbType.Int;
            id.Direction = ParameterDirection.Output;
            db.Database.ExecuteSqlCommand("GioHang_GetIDGioHangJustInsert @IDGioHang out", id);
            return id.Value.ToString();
        }
        public void Mua_Insert(Mua m)
        {
            object[] para = new SqlParameter[]
            {
                new SqlParameter("@SoLuong",m.SoLuong),
                new SqlParameter("@IDHoa",m.IDHoa),
                new SqlParameter("@IDGioHang",m.IDGioHang),
            };
            db.Database.ExecuteSqlCommand("Mua_InsertProc @SoLuong, @IDHoa, @IDGioHang", para);
        }
    }
}
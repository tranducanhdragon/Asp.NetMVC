using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoaTuoi.Models.DAO;
using HoaTuoi.Models.EF;

namespace HoaTuoi.Controllers
{
    public class CartHoaController : LoginController
    {
        private static string MuaSession = "MuaSession";
        public ActionResult Index()
        {
            var l = new List<Mua>();
            if (Session[MuaSession] != null)
            {
                l = (List<Mua>)Session[MuaSession];
                
            }
            return View(l);
        }
        [HttpGet]
        public ActionResult AddCart(int id)
        {
            var model = new HoaDAO().HoaByID(id);
            return View(model);
        }
        /*Mỗi list<Mua> chỉ mua được 1 loại hoa với số lượng ko giới hạn
        Muốn mua loại hoa khác thì tạo 1 list<Mua> mới rồi add vào Session*/
        [HttpPost]
        public ActionResult AddCart(int id, int SoLuongHoa)
        {
            var li = new List<Mua>();
            if (Session[MuaSession] != null)
            {
                li = (List<Mua>)Session[MuaSession];
                if(li.Exists(x=>x.IDHoa == id))
                {
                    li.Find(x=>x.IDHoa == id).SoLuong += SoLuongHoa;
                }
                else
                {
                    Mua m = new Mua();
                    m.IDHoa = id;
                    m.SoLuong = SoLuongHoa;
                    li.Add(m);
                }
            }
            else
            {               
                Mua m = new Mua();
                m.IDHoa = id;
                m.SoLuong = SoLuongHoa;
                li.Add(m);
                Session[MuaSession] = li;
            }            
            return RedirectToAction("Index");
        }
        public void DeleteMua(int IDHoa)
        {
            if(Session[MuaSession] != null)
            {
                var li = (List<Mua>)Session[MuaSession];
                li.Remove(li.Find(x => x.IDHoa == IDHoa));
                Session[MuaSession] = li;
            }
        }
        //Tạo giỏ hàng rồi add tất cả các Mua vào đó
        public ActionResult ThanhToan()
        {
            GioHang gh = new GioHang();
            gh.NgayTao = DateTime.Now;
            gh.SoLuongHoa = 0;
            gh.ThanhTien = 0;
            var li_mua = (List<Mua>)Session[MuaSession];
            foreach(var mua in li_mua)
            {
                gh.SoLuongHoa += mua.SoLuong;
                gh.ThanhTien += (mua.SoLuong * (new HoaDAO().HoaByID(mua.IDHoa).GiaTien));
            }
            new GioHangDAO().GioHang_Insert(gh);
            var idgh = new GioHangDAO().GioHang_GetIDJustInsert();
            //update IDGioHang cho cac Mua thuoc GioHang nay
            foreach (var mua in li_mua)
            {
                mua.IDGioHang = Convert.ToInt32(idgh);
                new GioHangDAO().Mua_Insert(mua);
            }
            Session[MuaSession] = li_mua;
            //Lấy thông tin người dùng và tiền thanh toán
            var nd = (NguoiDung)Session["NguoiDungSession"];
            dynamic multimodel = new ExpandoObject();
            if (nd != null)
            {               
                multimodel.TenNguoiDung = nd.TenNguoiDung;
                multimodel.Email = nd.Email;
                multimodel.DiaChi = nd.DiaChi;
                multimodel.DienThoai = nd.DienThoai;
                multimodel.ThanhTien = gh.ThanhTien;
                multimodel.TenDangNhap = nd.TenDangNhap;
                multimodel.TenNguoiDung = nd.TenNguoiDung;
            }
            return View(multimodel);
        }
    }
}
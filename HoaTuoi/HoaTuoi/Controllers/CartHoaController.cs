using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoaTuoi.Models.DAO;
using HoaTuoi.Models.EF;

namespace HoaTuoi.Controllers
{
    public class CartHoaController : LoginController
    {
        private static string CartSession = "CartSession";
        public ActionResult Index()
        {
            var l = new List<GioHang>();
            if (Session[CartSession] != null)
            {
                l = (List<GioHang>)Session[CartSession];
                
            }
            return View(l);
        }
        [HttpGet]
        public ActionResult AddCart(int id)
        {
            var model = new HoaDAO().HoaByID(id);
            return View(model);
        }
        /*Mỗi list giỏ hàng chỉ mua được 1 loại hoa với số lượng ko giới hạn
        Muốn mua loại hoa khác thì tạo 1 list giỏ hàng mới rồi add vào Session*/
        [HttpPost]
        public ActionResult AddCart(int id, int SoLuongHoa)
        {
            var li = new List<GioHang>();
            if (Session[CartSession] != null)
            {
                li = (List<GioHang>)Session[CartSession];
                if(li.Exists(x=>x.IDHoa == id))
                {
                    li.Find(x=>x.IDHoa == id).SoLuongHoa += SoLuongHoa;
                }
                else
                {
                    GioHang gh = new GioHang();
                    gh.IDGioHang = 1;
                    gh.IDHoa = id;
                    gh.NgayTao = DateTime.Now;
                    gh.SoLuongHoa = SoLuongHoa;
                    gh.ThanhTien = new HoaDAO().HoaByID(id).GiaTien * SoLuongHoa;
                    li.Add(gh);
                }
            }
            else
            {               
                GioHang gh = new GioHang();
                gh.IDGioHang = 1;
                gh.IDHoa = id;
                gh.NgayTao = DateTime.Now;
                gh.SoLuongHoa = SoLuongHoa;
                gh.ThanhTien = new HoaDAO().HoaByID(id).GiaTien * SoLuongHoa;
                li.Add(gh);
                
            }
            Session[CartSession] = li;
            return RedirectToAction("Index");
        }
        public void DeleteCart(int IDHoa)
        {
            if(Session[CartSession] != null)
            {
                var li = (List<GioHang>)Session[CartSession];
                li.Remove(li.Find(x => x.IDHoa == IDHoa));
                Session[CartSession] = li;
            }
        }
    }
}
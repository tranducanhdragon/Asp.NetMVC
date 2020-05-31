using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using HoaTuoi.Models.DAO;
using HoaTuoi.Models.EF;
using System.Dynamic;

namespace HoaTuoi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Slide = new SlideHoaDAO().Slide();
            return View();
        }
        public ActionResult Gallery()
        {
            var model = new HoaDAO().DanhSachHoa();
            return View(model);
        }
        [ChildActionOnly]
        public ActionResult PartialViewSoSanPham()
        {
            var nd = (NguoiDung)Session["NguoiDungSession"];
            var li = new List<Mua>();
            dynamic multimodel = new ExpandoObject();
            multimodel.SoLuongHoa = 0;
            multimodel.ThanhTien = 0;
            if(nd != null)
            {
                multimodel.TenDangNhap = nd.TenDangNhap;
                multimodel.TenNguoiDung = nd.TenNguoiDung;
            }
            else
            {
                multimodel.TenDangNhap = "";
                multimodel.TenNguoiDung = "";
            }
            if(Session["CartSession"] != null)
            {
                li = (List<Mua>)Session["CartSession"];
                foreach(var item in li)
                {
                    multimodel.SoLuongHoa += item.SoLuong;
                                        
                }
            }
            return PartialView(multimodel);
        }
        public ActionResult EndSession()
        {
            Session["NguoiDungSession"] = null; 
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
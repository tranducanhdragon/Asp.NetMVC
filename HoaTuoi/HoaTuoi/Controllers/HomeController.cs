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
            var li = new List<GioHang>();
            dynamic multimodel = new ExpandoObject();
            multimodel.SoLuongHoa = 0;
            multimodel.ThanhTien = 0;
            if(Session["CartSession"] != null)
            {
                li = (List<GioHang>)Session["CartSession"];
                foreach(var item in li)
                {
                    multimodel.SoLuongHoa += item.SoLuongHoa;
                    multimodel.ThanhTien += item.ThanhTien;                    
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
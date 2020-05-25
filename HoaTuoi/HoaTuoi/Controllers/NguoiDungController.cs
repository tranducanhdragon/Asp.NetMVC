using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoaTuoi.Models.EF;
using HoaTuoi.Models.DAO;

namespace HoaTuoi.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(NguoiDung modelLogin)
        {
            if (modelLogin.TenDangNhap != null && modelLogin.MatKhau != null)
            {
                NguoiDungDAO dao = new NguoiDungDAO();
                var result = dao.Login(modelLogin.TenDangNhap, modelLogin.MatKhau);
                //Kiểm tra tài khoản đó nếu đúng thì tạo session cho user này
                if (result)
                {
                    var user = dao.NguoiDungByUserName(modelLogin.TenDangNhap);
                    Session.Add("NguoiDungSession", user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login", "NguoiDung");
                }
            }
            return View("Index");
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(NguoiDung user)
        {
            var dao = new NguoiDungDAO();
            dao.NguoiDungInsert(user);
            return RedirectToAction("Index", "Home");
        }
    }
}
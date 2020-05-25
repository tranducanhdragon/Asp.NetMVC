using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using ThuVienOnline.Areas.Admin.Models;

namespace ThuVienOnline.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            //Kiểm tra các trường Username và Password ko được để trống
            if (ModelState.IsValid)
            {
                TaiKhoanDAO dao = new TaiKhoanDAO();
                var result = dao.Login(model.UserName, model.PassWord);
                //Kiểm tra tài khoản đó nếu đúng thì tạo session cho user này
                if (result)
                {
                    var user = dao.GetByName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.TenDangNhap;
                    userSession.UserID = user.MaTaiKhoan;
                    Session.Add(Common.CommonConst.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sai Tên Đăng Nhập Hoặc Mật Khẩu!");
                }
            }
            return View("Index");
        }
    }
}
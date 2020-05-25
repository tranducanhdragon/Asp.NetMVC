using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using PagedList;

namespace ThuVienOnline.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new TaiKhoanDAO();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        //Lấy id từ url( url có định dạng: controller/action/id)
        public ActionResult Edit(int id)
        {
            var user = new TaiKhoanDAO().GetByID(id);
            return View(user);
        }
        //Kiểm tra và insert tài khoản
        [HttpPost]
        public ActionResult Create(TaiKhoan user)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();
                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
            }
            else
            {
                ModelState.AddModelError("", "Thêm tài khoản thành công");
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(TaiKhoan user, int id)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();
                bool sua = dao.Update(user, id);
                if (sua)
                {
                    return RedirectToAction("Index", "User");
                }
            }
            else
            {
                ModelState.AddModelError("", "Chỉnh sửa tài khoản thành công");
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new TaiKhoanDAO();
            if (dao.Delete(id))
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "Xóa tài khoản thành công");
            }
            return View("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using PagedList;

namespace ThuVienOnline.Areas.Admin.Controllers
{
    public class SachController : BaseController
    {
        // GET: Admin/Sach
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new SachDAO();
            var model = dao.SachListPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var ddtentg = new TacGiaDAO().TenTG();
            ViewBag.HoTen = new SelectList(ddtentg);
            var ddtennxb = new NXBDAO().TenNXB();
            ViewBag.TenNXB = new SelectList(ddtennxb);
            var ddtentl = new TheLoaiDAO().TenTL();
            ViewBag.TenTheLoai = new SelectList(ddtentl);
            return View();
        }
        [HttpPost]
        public ActionResult Create(SachView sv)
        {
            if (ModelState.IsValid && Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                var path = Path.Combine(Server.MapPath("~/Assets/Admin/pic/Sach"), file.FileName);
                sv.AnhDaiDien = file.FileName;
                bool dao = new SachDAO().Insert(sv);
                file.SaveAs(path);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Thêm sách thành công");
                return RedirectToAction("Create");
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ddtentg = new TacGiaDAO().TenTG();
            ViewBag.HoTen = new SelectList(ddtentg);
            var ddtennxb = new NXBDAO().TenNXB();
            ViewBag.TenNXB = new SelectList(ddtennxb);
            var ddtentl = new TheLoaiDAO().TenTL();
            ViewBag.TenTheLoai = new SelectList(ddtentl);
            var dao = new SachDAO().GetSachByID(id);
            return View(dao);
        }
        [HttpPost]
        public ActionResult Edit(SachView s, int id)
        {
            if (ModelState.IsValid && Request.Files.Count > 0)
            {
                var dao = new SachDAO();
                var file = Request.Files[0];
                s.AnhDaiDien = file.FileName;
                var path = Path.Combine(Server.MapPath("~/Assets/Admin/pic/Sach"), file.FileName);
                bool sua = dao.Update(s, id);
                file.SaveAs(path);
                return RedirectToAction("Index", "Sach");
            }
            else
            {
                ModelState.AddModelError("", "Input không hợp lệ hoặc không có ảnh");
                return RedirectToAction("Edit", "Sach");
            }
        }
        [HttpPost]
        public void Delete(int MaSach)
        {
            var dao = new SachDAO();
            dao.Delete(MaSach);
        }
    }
}
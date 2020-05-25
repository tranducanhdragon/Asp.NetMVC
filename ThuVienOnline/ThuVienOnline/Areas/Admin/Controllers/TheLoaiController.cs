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
    public class TheLoaiController : BaseController
    {
        // GET: Admin/TheLoai
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new TheLoaiDAO();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new TheLoaiDAO().GetTheLoaiByID(id);
            return View(dao);
        }
        [HttpPost]
        public ActionResult Create(TheLoai tl)
        {
            if (Request.Files.Count > 0 && ModelState.IsValid)
            {
                var file = Request.Files[0];
                var dm = new TheLoaiDAO();
                if (file != null && file.ContentLength > 0)
                {
                    //Lưu file vào hệ thống và lưu tên file vào database
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Assets/Admin/pic/DanhMuc"), fileName);
                    file.SaveAs(path);
                    tl.AnhDaiDien = fileName;
                    dm.Insert(tl);
                    return RedirectToAction("Index", "TheLoai");
                }
            }
            else
            {
                ModelState.AddModelError("", "Thêm thể loại thành công");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(TheLoai tl, int id)
        {
            if (ModelState.IsValid && Request.Files.Count > 0)
            {
                var dao = new TheLoaiDAO();
                var file = Request.Files[0];
                tl.AnhDaiDien = file.FileName;
                var path = Path.Combine(Server.MapPath("~/Assets/Admin/pic/DanhMuc"), file.FileName);
                bool sua = dao.Update(tl, id);
                if (sua && file.ContentLength > 0)
                {
                    file.SaveAs(path);
                    return RedirectToAction("Index", "TheLoai");
                }
            }
            else
            {
                ModelState.AddModelError("", "Chỉnh sửa thể loại thành công");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int MaTheLoai)
        {
            var dao = new TheLoaiDAO();
            if (dao.Delete(MaTheLoai))
            {
                return RedirectToAction("Index", "TheLoai");
            }
            else
            {
                ModelState.AddModelError("", "Xóa thể loại thành công");
            }
            return RedirectToAction("Index");
        }
    }
}
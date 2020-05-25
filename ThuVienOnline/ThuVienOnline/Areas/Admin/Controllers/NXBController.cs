using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using PagedList;
using System.IO;
using Model.EF;

namespace ThuVienOnline.Areas.Admin.Controllers
{
    public class NXBController : BaseController
    {
        // GET: Admin/NXB
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new NXBDAO();
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
            var dao = new NXBDAO().GetNXBByID(id);
            return View(dao);
        }
        [HttpPost]
        public ActionResult Create(NXB nxb)
        {
            if (Request.Files.Count > 0 && ModelState.IsValid)
            {
                var file = Request.Files[0];
                var dao = new NXBDAO();
                if (file != null && file.ContentLength > 0)
                {
                    //Lưu file vào hệ thống và lưu tên file vào database
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Assets/Admin/pic/NXB"), fileName);
                    file.SaveAs(path);
                    nxb.AnhDaiDien = fileName;
                    dao.Insert(nxb);
                    return RedirectToAction("Index", "NXB");
                }
            }
            else
            {
                ModelState.AddModelError("", "Thêm NXB thành công");
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(NXB tl, int id)
        {
            if (ModelState.IsValid && Request.Files.Count > 0)
            {
                var dao = new NXBDAO();
                var file = Request.Files[0];
                tl.AnhDaiDien = file.FileName;
                var path = Path.Combine(Server.MapPath("~/Assets/Admin/pic/NXB"), file.FileName);
                bool sua = dao.Update(tl, id);
                if (sua && file.ContentLength > 0)
                {
                    file.SaveAs(path);
                    return RedirectToAction("Index", "NXB");
                }
            }
            else
            {
                ModelState.AddModelError("", "Chỉnh sửa NXB thành công");
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Delete(int MaNXB)
        {
            var dao = new NXBDAO();
            if (dao.Delete(MaNXB))
            {
                return RedirectToAction("Index", "NXB");
            }
            else
            {
                ModelState.AddModelError("", "Xóa NXB thành công");
            }
            return View("Index");
        }
    }
}
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
    public class TacGiaController : BaseController
    {
        // GET: Admin/TacGia
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new TacGiaDAO();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TacGia tg)
        {
            if (ModelState.IsValid)
            {
                var dao = new TacGiaDAO();
                dao.Create(tg);
            }
            else
            {
                ModelState.AddModelError("", "Không hợp lệ");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public void Delete(int MaTG)
        {
            var dao = new TacGiaDAO();
            dao.Delete(MaTG);
        }
    }
}
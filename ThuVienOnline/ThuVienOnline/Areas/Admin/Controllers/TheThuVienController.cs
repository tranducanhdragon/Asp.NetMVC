﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;

namespace ThuVienOnline.Areas.Admin.Controllers
{
    public class TheThuVienController : Controller
    {
        // GET: Admin/TheThuVien
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new TheThuVienDAO();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        public ActionResult Create()
        {
            //Lấy dữ liệu cho DropDownList Nhân Viên
            ThuVienOnlineDBContext db = new ThuVienOnlineDBContext();
            var li = (db.NhanViens.Select(x => new { Text = x.IDNhanVien + "." + x.HoTen, Value = x.IDNhanVien })).ToList();
            ViewBag.DDNhanVien = new SelectList(li, "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult Create(TheThuVien the)
        {
            new TheThuVienDAO().Insert(the);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Lấy dữ liệu cho DropDownList Nhân Viên
            ThuVienOnlineDBContext db = new ThuVienOnlineDBContext();
            var li = (db.NhanViens.Select(x => new { Text = x.IDNhanVien + "." + x.HoTen, Value = x.IDNhanVien })).ToList();
            ViewBag.DDNhanVien = new SelectList(li, "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id, TheThuVien the)
        {
            if (ModelState.IsValid)
            {
                var dao = new TheThuVienDAO().Update(the, id);
                if (dao)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Edit");
                }
            }
            else
            {
                return RedirectToAction("Edit");
            }
        }
        [HttpPost]
        public void Delete(int IDThe)
        {
            var dao = new TheThuVienDAO().Delete(IDThe);
        }
        public ActionResult MuonFromTheThuVien(int id)
        {
            ViewBag.IDThe = id;
            var modelMuon = new TheThuVienDAO().MuonListAllPaging(id, 1, 10);
            return PartialView("PartialViewXem" , modelMuon);
        }
        public ActionResult MuonSachView(int id)
        {
            var sachview = new SachDAO().SachListPaging(1, 10);
            ViewBag.IDThe = id;
            return PartialView("MuonSach", sachview);
        }
        [HttpPost]
        public ActionResult Muon(int IDSach, int IDThe, int SoLuongSach)
        {
            new TheThuVienDAO().InsertMuon(IDThe, IDSach, SoLuongSach);
            ViewBag.IDThe = IDThe;
            var modelMuon = new TheThuVienDAO().MuonListAllPaging(IDThe, 1, 10);
            return PartialView("PartialViewXem", modelMuon);
        }
        [HttpPost]
        public ActionResult Tra(int IDSach, int IDThe)
        {
            new TheThuVienDAO().DeleteMuon(IDThe, IDSach);
            ViewBag.IDThe = IDThe;
            var modelMuon = new TheThuVienDAO().MuonListAllPaging(IDThe, 1, 10);
            return PartialView("PartialViewXem", modelMuon);
        }
        [HttpPost]
        public JsonResult ChangeTrangThai(int IDThe)
        {
            var dao = new TheThuVienDAO().ChangeTrangThai(IDThe);
            return Json(new { status = dao }, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using ThuVienOnline.Areas.Admin.Models;
using PagedList;

namespace ThuVienOnline.Areas.Admin.Controllers
{
    public class TacGiaController : BaseController
    {
        // GET: Admin/TacGia
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            //Gửi 1 yêu cầu Get đến TacGiaApi controller và lấy dữ liệu từ api đó 
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49182/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/TacGiaApi").Result;
            if (response.IsSuccessStatusCode)
            {
                var tg = response.Content.ReadAsAsync<IEnumerable<TacGiaApi>>().Result;
                tg.ToPagedList(1, 10);
                return View(tg);
            }
            else
            {
                var dao = new TacGiaDAO();
                var model = dao.ListAllPaging(page, pageSize);
                return View(model);
            } 
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
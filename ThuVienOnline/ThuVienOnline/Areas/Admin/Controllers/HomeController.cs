using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace ThuVienOnline.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var modelDM = new TheLoaiDAO().ListAllPaging(1, 10);
            return View(modelDM);
        }
        //Lấy tất cả sách theo danh mục
        public ActionResult SachFromDM(int id)
        {
            var modelSach = new SachDAO().SachByDMPaging(id, 1, 10);
            return PartialView("PartialViewGetSachFromDM" ,modelSach);
        }
    }
}
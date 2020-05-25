using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var message = new MessageModel();
            message.Welcome = "Chao mung Duc Anh Tran";
            return View(message);
        }
        public ActionResult Main()
        {
            return View();
        }
    }
}
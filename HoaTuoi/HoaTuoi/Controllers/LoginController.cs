using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HoaTuoi.Models.EF;

namespace HoaTuoi.Controllers
{
    public class LoginController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (NguoiDung)Session["NguoiDungSession"];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "NguoiDung", Action = "Login"}));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}
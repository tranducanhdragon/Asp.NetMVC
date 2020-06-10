using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace ThuVienOnline.Areas.Admin.Models.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                         new System.Web.Routing.RouteValueDictionary(
                          new
                          {
                              Controller = "Login",
                              Action = "Index",
                              ReturnUrl = filterContext.HttpContext.Request.RawUrl
                          }));
                return;
            }
            var acc = (Account)HttpContext.Current.Session["UserLogin"];

            if (acc == null)
            {
                //  filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Account", Action = "Index" }));
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new
                        {
                            Controller = "Login",
                            Action = "Index",
                            ReturnUrl = filterContext.HttpContext.Request.RawUrl
                        }));
            }
            else
            {
                CustomPrincipal cp = new CustomPrincipal(acc);
                //Kiểm tra nếu user này ko có role thì redirect đến Login
                if (!cp.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(
                            new { Controller = "Login", Action = "Index" }));
                }
            }
        }
    }
}
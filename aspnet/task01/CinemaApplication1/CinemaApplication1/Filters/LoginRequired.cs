using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaApplication1.Filters
{
    public class LoginRequired : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["authorization"] == null)
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
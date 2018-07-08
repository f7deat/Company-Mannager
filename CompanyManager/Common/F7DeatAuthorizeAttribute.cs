using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyManager.Common
{
    public class F7DeatAuthorizeAttribute: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (UserInfo)HttpContext.Current.Session[Constants.USER_SESSION];
            if (session == null)
            {
                httpContext.Response.Redirect("~/");
                return false;
            }
            if (Roles.Contains(session.Roles.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
            //return base.AuthorizeCore(httpContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/Shared/401.cshtml"
            };
        }
    }
}
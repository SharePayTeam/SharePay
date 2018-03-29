using System.Web.Mvc;

namespace SharePay.Web.Filters
{
    public class RestrictAuthorizedAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/Dashboard/Index");
            }
        }
    }
}
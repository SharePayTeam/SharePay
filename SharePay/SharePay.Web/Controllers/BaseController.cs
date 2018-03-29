using Microsoft.AspNet.Identity.Owin;
using SharePay.Common.Services;
using System.Web;
using System.Web.Mvc;

namespace SharePay.Web.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationUserManager applicationUserManager;
        private ApplicationSignInManager applicationSignInManager;

        protected ApplicationUserManager ApplicationUserManager
        {
            get
            {
                if (this.applicationUserManager == null)
                {
                    this.applicationUserManager = HttpContext.GetOwinContext().Get<ApplicationUserManager>();
                }

                return applicationUserManager;
            }
        }

        protected ApplicationSignInManager ApplicationSignInManager
        {
            get
            {
                if (this.applicationSignInManager == null)
                {
                    this.applicationSignInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
                }

                return applicationSignInManager;
            }
        }
    }
}
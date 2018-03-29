using SharePay.Web.Filters;
using System.Web.Mvc;

namespace SharePay.Web.Controllers
{
    [RestrictAuthorized]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.ActiveTab = "home";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
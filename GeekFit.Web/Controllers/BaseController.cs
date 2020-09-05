using System.Web.Mvc;

namespace GeekFit.Web.Controllers
{
    public class BaseController : Controller
    {
        protected RedirectToRouteResult RedirectToList()
        {
            return RedirectToAction("list");
        }
    }
}
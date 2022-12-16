
using Microsoft.AspNetCore.Mvc;

namespace GeekFit.Web.Controllers
{
    public class BaseController : Controller
    {
        protected RedirectToActionResult RedirectToList()
        {
            return RedirectToAction("list");
        }
    }
}
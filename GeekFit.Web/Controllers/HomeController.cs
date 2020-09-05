using GeekFit.Services;
using GeekFit.Web.Models;
using System.Web.Mvc;

namespace GeekFit.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly WorkoutService _service;

        public HomeController(WorkoutService service)
        {
            _service = service;
        }

        [Route]
        public ActionResult Index()
        {
            return View(new HomeViewModel
            {
                Users = _service.GetUsers()
            });
        }
    }
}
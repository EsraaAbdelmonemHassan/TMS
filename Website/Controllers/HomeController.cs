using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.IsAdmin = User.IsInRole("Admin");
            return View("~/Views/Home/Index.cshtml");
        }
    }
}

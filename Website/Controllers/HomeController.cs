using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index() =>
            View("~/Views/Home/Index.cshtml");
    }
}

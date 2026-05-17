using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class RootController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index() => Redirect("/home");
    }
}

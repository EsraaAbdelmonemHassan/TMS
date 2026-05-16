using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet("/")]
        public IActionResult Index() => View();

        [HttpGet("/contacts")]
        public IActionResult Contacts() => View();

        [HttpGet("/departments")]
        public IActionResult Departments() => View();

        [HttpGet("/employees")]
        public IActionResult Employees() => View();

        [HttpGet("/administrators")]
        public IActionResult Administrators() => View();

        [HttpGet("/settings")]
        public IActionResult Settings() => View();
    }
}

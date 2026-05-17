namespace Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Olive.Security;
    using System.Threading.Tasks;

    [Route("logout")]
    public class LogoutController : Controller
    {
        [HttpGet, HttpPost]
        public async Task<IActionResult> Index()
        {
            await OAuth.Instance.LogOff();
            return Redirect("/home");
        }
    }
}

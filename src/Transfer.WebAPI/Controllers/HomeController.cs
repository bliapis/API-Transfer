using Microsoft.AspNetCore.Mvc;

namespace Transfer.WebAPI.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Get() => Content("Hello, teste API");
    }
}
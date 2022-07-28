using Microsoft.AspNetCore.Mvc;

namespace LMS.Web.Areas.Demos.Controllers
{
    [Area("Demos")]
    public class MyFirstDemoController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Hello World");
        }
    }
}

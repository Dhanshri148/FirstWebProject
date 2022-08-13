using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HomePage.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyFirstApiController : ControllerBase
    {
        [HttpGet]

        public IActionResult Index()
        {
            return Ok(new string[] {"Hello", "World"});
        }

    }
}

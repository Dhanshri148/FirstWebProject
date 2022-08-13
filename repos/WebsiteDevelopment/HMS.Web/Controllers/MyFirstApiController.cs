using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyFirstApiController : ControllerBase
    {
        [HttpGet]
        [ActionName("GetData")]
        public IActionResult GetData()
        {
            var obj = new
            {
                Id = 20,
                Name = "First Customer",
                IsAvailable = true,
                DOB = DateTime.Now
            };

            return Ok(obj);
        }
        
    }
}

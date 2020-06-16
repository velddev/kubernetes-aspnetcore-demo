using System;
using Microsoft.AspNetCore.Mvc;

namespace ExampleService.Controllers
{
    [Route("test")]
    [Controller]
    public class GiftCodesController : Controller
    {
        [HttpGet]
        public IActionResult GetTestAsync()
        {
            return Ok($"Hello, this is the machine named {Environment.MachineName}");
        }
    }
}

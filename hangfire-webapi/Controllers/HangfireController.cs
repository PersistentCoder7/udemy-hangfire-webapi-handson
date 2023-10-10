using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;

namespace hangfire_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangfireController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from hangfire api!");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Welcome()
        {
            var JobId = BackgroundJob.Enqueue(() => SendWelcomeEmail("Welcome to our app"));
            return Ok($"Job Id: {JobId}, Welcome email sent to the user!");
        }

        public void SendWelcomeEmail(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}

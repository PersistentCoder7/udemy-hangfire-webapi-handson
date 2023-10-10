using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        [HttpPost]
        [Route("[action]")]
        public IActionResult Discount()
        {
            int delay = 30;
            var JobId = BackgroundJob.Schedule(() => SendWelcomeEmail("Discount offered by our app"),TimeSpan.FromSeconds(delay));
            return Ok($"Job Id: {JobId}, Discount email will be sent to the user after {delay} seconds!");
        }


        public void SendWelcomeEmail(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}

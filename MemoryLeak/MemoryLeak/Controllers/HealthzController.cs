using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryLeak.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthzController : ControllerBase
    {
        [HttpGet]
        public IActionResult CheckHealthz()
        {
            return Ok();
        }
    }
}

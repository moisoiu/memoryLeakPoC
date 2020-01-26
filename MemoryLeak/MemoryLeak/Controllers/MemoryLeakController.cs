using MemoryLeak.Managers;
using MemoryLeak.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryLeak.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemoryLeakController : ControllerBase
    {
        private readonly IMemoryLeakManager memoryLeakManager;

        public MemoryLeakController(IMemoryLeakManager memoryLeakManager)
        {
            this.memoryLeakManager = memoryLeakManager;
        }

        [HttpGet("generate-via-concurrent-bag")]
        public async Task<IActionResult> GenerateMemoryLeakObjectViaConcurentBag()
        {
            await memoryLeakManager.GenerateMemoryLeakObjectViaConcurentBag();
            return Ok();
        }

        [HttpGet("memory-leak-via-static")]
        public async Task<IActionResult> MemoryLeakObject()
        {
            await memoryLeakManager.GenerateMemoryLeak();
            return Ok();

        }
    }
}

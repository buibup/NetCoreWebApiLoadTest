using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repositories.Runnings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunningOrderRefNoController : ControllerBase
    {
        public IRunningOrderRefNoRepository RunningOrderRefNoRepo { get; }
        public RunningOrderRefNoController(IRunningOrderRefNoRepository runningOrderRefNoRepo)
        {
            RunningOrderRefNoRepo = runningOrderRefNoRepo;
        }

        [HttpGet]
        public async Task<string> GetGetRunningOrderRefNo()
        {
            var running = await RunningOrderRefNoRepo.GetRunningOrderRefNo();
            return running;
        }
    }
}
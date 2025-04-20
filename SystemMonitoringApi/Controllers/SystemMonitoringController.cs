using Microsoft.AspNetCore.Mvc;
using SystemMonitoringApi.Models;

namespace SystemMonitoringApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemMonitoringController : ControllerBase
    {
        private readonly ILogger<SystemMonitoringController> _logger;

        public SystemMonitoringController(ILogger<SystemMonitoringController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult ReceiveSystemStats([FromBody] SystemStats stats)
        {
            if (stats == null)
                return BadRequest("Invalid data.");

            // Log to Console
            _logger.LogInformation("System Data Received: CPU: {Cpu}%, RAM Used: {RamUsed} MB, Disk Used: {DiskUsed} MB",
                stats.Cpu, stats.Ram_Used, stats.Disk_Used);

            // Optional: Save to file, DB, etc.

            return Ok(new { message = "System stats received successfully." });
        }
    }
}

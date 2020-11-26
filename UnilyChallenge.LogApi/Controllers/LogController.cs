using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnilyChallenge.LogApi.Models;
using UnilyChallenge.LogApi.Services;

namespace UnilyChallenge.LogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogWriter _logWriter;

        public LogController(ILogWriter logWriter)
        {
            _logWriter = logWriter;
        }

        [HttpPost]
        public async Task<IActionResult> WriteLog([FromBody]LogEntry logEntry)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _logWriter.WriteLogAsync(logEntry.Id, logEntry.Timestamp, logEntry.Message);

            return Ok();
        }
    }
}

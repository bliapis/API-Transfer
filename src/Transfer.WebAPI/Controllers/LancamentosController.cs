using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using Transfer.Common.Commands;

namespace Transfer.WebAPI.Controllers
{
    [Route("[controller]")]
    public class LancamentosController : Controller
    {
        private readonly IBusClient _busClient;
        public LancamentosController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateLancamento command)
        {
            command.Id = Guid.NewGuid();
            command.Data = DateTime.UtcNow;
            await _busClient.PublishAsync(command);

            return Accepted($"lancamento/{command.Id}");
        }
    }
}
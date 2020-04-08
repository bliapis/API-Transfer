using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using Transfer.Common.Commands;
using Transfer.WebAPI.Repositories;

namespace Transfer.WebAPI.Controllers
{
    [Route("lancamentos")]
    public class LancamentosController : Controller
    {
        private readonly IBusClient _busClient;
        private readonly ILancamentoRepository _repository;

        public LancamentosController(IBusClient busClient,
            ILancamentoRepository lancamentoRepository)
        {
            _busClient = busClient;
            _repository = lancamentoRepository;
        }

        [HttpGet]
        public IActionResult Get() => Content("Lancamentos API");

        [HttpGet("")]
        public async Task<IActionResult> Get(int contaOrigem)
        {
            var lancamentos = await _repository
                .GetByContaOrigem(contaOrigem);

            if (!lancamentos.Any())
                return NotFound();

            return Json(lancamentos.Select(x => new { x.Id, x.Data, x.ContaOrigem, x.ContaDestino }));
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
using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Threading.Tasks;
using Transfer.Common.Commands;
using Transfer.Common.Events;
using Transfer.Common.Exceptions;
using Transfer.Services.Lancamentos.Services;

namespace Transfer.Services.Lancamentos.Handler
{
    public class CreateLancamentoHandler : ICommandHandler<CreateLancamento>
    {
        private readonly IBusClient _bus;
        private readonly ILancamentoService _lancService;
        private ILogger _logger;

        public CreateLancamentoHandler(IBusClient bus,
            ILancamentoService lancamentoService,
            ILogger<CreateLancamentoHandler> logger)
        {
            _bus = bus;
            _lancService = lancamentoService;
            _logger = logger;
        }

        public async Task HandleAsync(CreateLancamento command)
        {
            _logger.LogInformation($"Criando o lançamento: {command.Id}");

            try
            {
                await _lancService.AddAsync(command.Id, command.Data, command.ContaOrigem, command.ContaDestino, command.Valor);

                await _bus.PublishAsync(new LancamentoCreated(command.Id, command.UserId, command.Data,
                command.ContaOrigem, command.ContaDestino, command.Valor));

                return;
            }
            catch(TransferException ex)
            {
                await _bus.PublishAsync(new CreateLancamentoRejected(command.Id, ex.Code, ex.Message));
                _logger.LogError(ex.Message);
            }
            catch(Exception ex)
            {
                await _bus.PublishAsync(new CreateLancamentoRejected(command.Id, "error", ex.Message));
                _logger.LogError(ex.Message);
            }
        }
    }
}
using RawRabbit;
using System;
using System.Threading.Tasks;
using Transfer.Common.Commands;
using Transfer.Common.Events;

namespace Transfer.Services.Identity.Handler
{
    public class CreateLancamentoHandler : ICommandHandler<CreateLancamento>
    {
        private readonly IBusClient _bus;

        public CreateLancamentoHandler(IBusClient bus)
        {
            _bus = bus;
        }

        public async Task HandleAsync(CreateLancamento command)
        {
            Console.WriteLine($"Criando o lançamento: {command.Id}");
            await _bus.PublishAsync(new LancamentoCreated(command.Id, command.UserId, command.Data,
                command.ContaOrigem, command.ContaDestino, command.Valor));
        }
    }
}
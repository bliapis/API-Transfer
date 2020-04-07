using System;
using System.Threading.Tasks;
using Transfer.Common.Events;

namespace Transfer.WebAPI.Handlers
{
    public class LancamentoCreatedHandler : IEventHandler<LancamentoCreated>
    {
        public LancamentoCreatedHandler()
        {

        }

        public async Task HandleAsync(LancamentoCreated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"Lancamento criado: @{@event.Id}");
        }
    }
}
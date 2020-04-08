using System;
using System.Threading.Tasks;
using Transfer.Common.Events;
using Transfer.WebAPI.Models;
using Transfer.WebAPI.Repositories;

namespace Transfer.WebAPI.Handlers
{
    public class LancamentoCreatedHandler : IEventHandler<LancamentoCreated>
    {
        private readonly ILancamentoRepository _lancRepo;

        public LancamentoCreatedHandler(ILancamentoRepository lancamentoRepository)
        {
            _lancRepo = lancamentoRepository;
        }

        public async Task HandleAsync(LancamentoCreated @event)
        {
            await _lancRepo.AddAsync(new Lancamento
            {
                Id = @event.Id,
                Data = @event.Data,
                ContaOrigem = @event.ContaOrigem,
                ContaDestino = @event.ContaDestino
            });
            Console.WriteLine($"Lancamento criado: @{@event.Id}");
        }
    }
}
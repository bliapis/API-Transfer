using System;
using System.Threading.Tasks;
using Transfer.Common.Exceptions;
using Transfer.Services.Lancamentos.Domain.Models;
using Transfer.Services.Lancamentos.Domain.Repositories;

namespace Transfer.Services.Lancamentos.Services
{
    public class LancamentoService : ILancamentoService
    {
        private readonly ILancamentoRepository _lancacamentoRepo;
        private readonly IContaCorrenteRepository _accRepo;

        public LancamentoService(ILancamentoRepository lancacamentoRepo
            ,IContaCorrenteRepository accRepo
            )
        {
            _lancacamentoRepo = lancacamentoRepo;
            _accRepo = accRepo;
        }

        public async Task AddAsync(Guid id, DateTime data, int contaOrigem, int contaDestino, decimal valor)
        {
            var accOrigem = await _accRepo.GetAsync(contaOrigem);
            var accDestino = await _accRepo.GetAsync(contaDestino);
            
            if(accOrigem == null)
            {
                throw new TransferException("Conta origem não existe",
                    $"Conta Origem: '{contaOrigem} não encontrada");
            }
            
            if (accDestino == null)
            {
                throw new TransferException("Conta destino não existe",
                    $"Conta Destino: '{accDestino} não encontrada");
            }

            var lancamento = new Lancamento(id, data, contaOrigem, contaDestino, valor);
            await _lancacamentoRepo.AddAsync(lancamento);
        }
    }
}
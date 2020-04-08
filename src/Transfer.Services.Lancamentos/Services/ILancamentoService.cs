using System;
using System.Threading.Tasks;

namespace Transfer.Services.Lancamentos.Services
{
    public interface ILancamentoService
    {
        Task AddAsync(Guid id, DateTime data, int contaOrigem, int contaDestino, decimal valor);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transfer.Services.Lancamentos.Domain.Models;

namespace Transfer.Services.Lancamentos.Domain.Repositories
{
    public interface ILancamentoRepository
    {
        Task<Lancamento> GetAsync(Guid lancamentoId);
        Task<IEnumerable<Lancamento>> GetByContaAsync(int contaOrigem);
        Task AddAsync(Lancamento lancamento);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transfer.WebAPI.Models;

namespace Transfer.WebAPI.Repositories
{
    public interface ILancamentoRepository
    {
        Task<Lancamento> GetAsync(Guid lancamentoId);
        Task AddAsync(Lancamento model);
        Task<IEnumerable<Lancamento>> GetByContaOrigem(int contaOrigem);
    }
}
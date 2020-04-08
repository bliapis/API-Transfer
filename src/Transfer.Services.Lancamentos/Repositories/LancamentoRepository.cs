using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Transfer.Services.Lancamentos.Domain.Models;
using Transfer.Services.Lancamentos.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Transfer.Services.Lancamentos.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly IMongoDatabase _database;

        public LancamentoRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(Lancamento lancamento)
            => await Collection.InsertOneAsync(lancamento);

        public async Task<Lancamento> GetAsync(Guid lancamentoId)
            => await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(l => l.Id.Equals(lancamentoId));

        public async Task<IEnumerable<Lancamento>> GetByContaAsync(int contaOrigem)
            => await Collection
            .AsQueryable()
            .Where(l => l.ContaOrigem.Equals(contaOrigem)).ToListAsync();

        private IMongoCollection<Lancamento> Collection
            => _database.GetCollection<Lancamento>("Lancamentos");
    }
}
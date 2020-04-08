using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transfer.WebAPI.Models;

namespace Transfer.WebAPI.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly IMongoDatabase _database;

        public LancamentoRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(Lancamento model)
            => await Collection.InsertOneAsync(model);

        public async Task<Lancamento> GetAsync(Guid lancamentoId)
            => await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.Id == lancamentoId);

        public async Task<IEnumerable<Lancamento>> GetByContaOrigem(int contaOrigem)
            => await Collection
            .AsQueryable()
            .Where(l => l.ContaOrigem.Equals(contaOrigem)).ToListAsync();

        private IMongoCollection<Lancamento> Collection
            => _database.GetCollection<Lancamento>("Lancamentos");
    }
}
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Transfer.Services.Lancamentos.Domain.Models;
using Transfer.Services.Lancamentos.Domain.Repositories;

namespace Transfer.Services.Lancamentos.Repositories
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly IMongoDatabase _database;

        public ContaCorrenteRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(ContaCorrente acc)
            => await Collection.InsertOneAsync(acc);

        public async Task<ContaCorrente> GetAsync(int numero)
        => await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(l => l.Numero.Equals(numero));

        private IMongoCollection<ContaCorrente> Collection
            => _database.GetCollection<ContaCorrente>("ContasCorrentes");
    }
}
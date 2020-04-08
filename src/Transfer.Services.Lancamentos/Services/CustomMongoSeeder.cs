using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transfer.Common.Mongo;
using Transfer.Services.Lancamentos.Domain.Models;
using Transfer.Services.Lancamentos.Domain.Repositories;

namespace Transfer.Services.Lancamentos.Services
{
    public class CustomMongoSeeder : MongoSeeder
    {
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly IContaCorrenteRepository _accRepo;

        public CustomMongoSeeder(IMongoDatabase database,
            ILancamentoRepository lancamentoRepository,
            IContaCorrenteRepository accRepo) : base(database)
        {
            _lancamentoRepository = lancamentoRepository;
            _accRepo = accRepo;
        }

        protected override async Task CustomSeedAsync()
        {
            #region Inicia base com lançamentos
            var lancamentos = new List<Lancamento>()
            {
                new Lancamento(Guid.NewGuid(), DateTime.UtcNow, 123, 980, 222),
                new Lancamento(Guid.NewGuid(), DateTime.UtcNow, 980, 321, 333),
                new Lancamento(Guid.NewGuid(), DateTime.UtcNow, 123, 321, 444)
            };

            await Task.WhenAll(lancamentos.Select(x =>
                _lancamentoRepository.AddAsync(new Lancamento(x.Id, x.Data, x.ContaOrigem, x.ContaDestino, x.Valor))));
            #endregion

            #region Inicia base com contas
            var accs = new List<ContaCorrente>()
            {
                new ContaCorrente(Guid.NewGuid(), 123),
                new ContaCorrente(Guid.NewGuid(), 980),
                new ContaCorrente(Guid.NewGuid(), 321)
            };

            await Task.WhenAll(accs.Select(a =>
                _accRepo.AddAsync(new ContaCorrente(a.Id, a.Numero))));
            #endregion
        }
    }
}
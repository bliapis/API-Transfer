using Moq;
using System;
using System.Threading.Tasks;
using Transfer.Common.Exceptions;
using Transfer.Services.Lancamentos.Domain.Models;
using Transfer.Services.Lancamentos.Domain.Repositories;
using Transfer.Services.Lancamentos.Services;
using Xunit;

namespace Transfer.Services.Lancamentos.Tests.Unit.Services
{
    public class LancamentoServicesTests
    {
        [Fact]
        public async void Lancamento_Service_AddAsync_Deve_Retornar_Success()
        {
            var contaOrigem = new ContaCorrente(Guid.NewGuid(), 123);

            var lancamentoRepositoryMock = new Mock<ILancamentoRepository>();
            var accRepositoryMock = new Mock<IContaCorrenteRepository>();

            accRepositoryMock.Setup(x => x.GetAsync(123))
                .ReturnsAsync(new ContaCorrente(contaOrigem.Id, contaOrigem.Numero));

            var _service = new LancamentoService(lancamentoRepositoryMock.Object,
                accRepositoryMock.Object);

            await _service.AddAsync(Guid.NewGuid(), DateTime.UtcNow, 123, 123, 9998);

            lancamentoRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Lancamento>()), Times.Once);
        }
    }
}
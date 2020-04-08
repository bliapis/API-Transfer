using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using RawRabbit;
using FluentAssertions;
using Transfer.Common.Commands;
using Transfer.WebAPI.Controllers;
using Transfer.WebAPI.Repositories;

namespace Transfer.WebAPI.Tests.Controllers
{
    public class LancamentosControllerTests
    {
        private Mock<IBusClient> _busMock;
        private Mock<ILancamentoRepository> _lancRepoMock;
        private LancamentosController _controller;

        public LancamentosControllerTests()
        {
            _busMock = new Mock<IBusClient>();
            _lancRepoMock = new Mock<ILancamentoRepository>();
            _controller = new LancamentosController(_busMock.Object, _lancRepoMock.Object);
        }

        [Fact]
        public void Lancamentos_Controller_Retorna_string_content()
        {
            var result = _controller.Get();

            var contentResult = result as ContentResult;
            contentResult.Should().NotBeNull();
            contentResult.Content.ShouldAllBeEquivalentTo("Lancamentos API");
        }

        [Fact]
        public async void Lancamentos_Controller_Post_Deve_Retornar_Accepted()
        {
            var command = new CreateLancamento
            {
                Id = Guid.NewGuid(),
                Data = DateTime.UtcNow,
                ContaOrigem = 123,
                ContaDestino = 321,
                Valor = 870
            };

            var result = await _controller.Post(command);

            var contentResult = result as AcceptedResult;
            contentResult.Should().NotBeNull();
            contentResult.Location.ShouldBeEquivalentTo($"lancamento/{command.Id}");
        }
    }
}
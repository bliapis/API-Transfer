using System;
using Transfer.Common.Exceptions;

namespace Transfer.Services.Lancamentos.Domain.Models
{
    public class Lancamento
    {
        public Guid Id { get; protected set; }
        public DateTime Data { get; protected set; }
        public int ContaOrigem { get; protected set; }
        public int ContaDestino { get; protected set; }
        public decimal Valor { get; protected set; }
        protected Lancamento() { }

        public Lancamento(Guid id, DateTime data, int contaOrigem, int contaDestino, decimal valor)
        {
            if (id == Guid.Empty)
            {
                throw new TransferException("id_lancamento_vazio",
                    $"O id do lançamento não pode ser vazio.");
            }

            if (data == null)
            {
                throw new TransferException("data_lancamento_vazia",
                    $"A data do lançamento não pode ser vazia.");
            }

            Id = id;
            Data = data;
            Data = DateTime.UtcNow;
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
            Valor = valor;
        }
    }
}
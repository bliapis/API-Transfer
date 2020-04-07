using System;

namespace Transfer.Services.Lancamentos.Domain.Models
{
    public class Lancamento
    {
        public Guid Id { get; protected set; }
        public DateTime Data { get; protected set; }
        public Guid ContaOrigemId { get; protected set; }
        public Guid ContaDestinoId { get; protected set; }

        protected Lancamento() { }

        public Lancamento(Guid id, DateTime data, Guid contaOrigemId, Guid contaDestinoId)
        {
            Id = id;
            Data = data;
            Data = DateTime.UtcNow;
            ContaOrigemId = contaOrigemId;
            ContaDestinoId = ContaDestinoId;
        }
    }
}
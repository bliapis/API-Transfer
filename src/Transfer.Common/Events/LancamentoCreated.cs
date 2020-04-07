using System;

namespace Transfer.Common.Events
{
    public class LancamentoCreated : IAuthenticatedEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public DateTime Data { get; }
        public int ContaOrigem { get; }
        public int ContaDestino { get; }
        public decimal Valor { get; }

        protected LancamentoCreated() {}

        public LancamentoCreated(Guid id, Guid userId, DateTime data,
            int contaOrigem, int contaDestino, decimal valor)
        {
            Id = id;
            UserId = userId;
            Data = data;
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
            Valor = valor;
        }
    }
}
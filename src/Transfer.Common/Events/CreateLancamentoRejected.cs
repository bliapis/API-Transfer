using System;

namespace Transfer.Common.Events
{
    public class CreateLancamentoRejected : IRejectedEvent
    {
        public string Code { get; }
        public string Reason { get; }
        public Guid LancamentoId { get; }
        public int ContaOrigem { get; }
        public int ContaDestino { get; }
        public decimal Valor { get; }

        protected CreateLancamentoRejected(){}
        public CreateLancamentoRejected(string code, string reason, Guid lancamentoId,
            int contaOrigem, int contaDestino, decimal valor)
        {
            Code = code;
            Reason = reason;
            LancamentoId = lancamentoId;
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
            Valor = valor;
        }
    }
}
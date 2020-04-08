using System;

namespace Transfer.Common.Events
{
    public class CreateLancamentoRejected : IRejectedEvent
    {
        public string Code { get; }
        public string Reason { get; }
        public Guid Id { get; }
        public int ContaOrigem { get; }
        public int ContaDestino { get; }
        public decimal Valor { get; }

        protected CreateLancamentoRejected(){}
        public CreateLancamentoRejected(Guid id, string code, string reason)
        {
            Code = code;
            Reason = reason;
            Id = id;
        }
    }
}
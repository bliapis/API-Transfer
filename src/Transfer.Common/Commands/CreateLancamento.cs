using System;

namespace Transfer.Common.Commands
{
    public class CreateLancamento : IAuthenticatedCommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Data { get; set; }
        public int ContaOrigem { get; set; }
        public int ContaDestino { get; set; }
        public decimal Valor { get; set; }
    }
}
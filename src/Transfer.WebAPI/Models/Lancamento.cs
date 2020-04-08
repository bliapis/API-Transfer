using System;

namespace Transfer.WebAPI.Models
{
    public class Lancamento
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public int ContaOrigem { get; set; }
        public int ContaDestino { get; set; }
    }
}

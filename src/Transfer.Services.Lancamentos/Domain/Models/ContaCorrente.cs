using System;

namespace Transfer.Services.Lancamentos.Domain.Models
{
    public class ContaCorrente
    {
        public Guid Id { get; protected set; }

        public int Numero { get; protected set; }

        protected ContaCorrente() { }

        public ContaCorrente(Guid id, int numero)
        {
            Id = id;
            Numero = numero;
        }
    }
}
using System.Threading.Tasks;
using Transfer.Services.Lancamentos.Domain.Models;

namespace Transfer.Services.Lancamentos.Domain.Repositories
{
    public interface IContaCorrenteRepository
    {
        Task<ContaCorrente> GetAsync(int numero);
    }
}
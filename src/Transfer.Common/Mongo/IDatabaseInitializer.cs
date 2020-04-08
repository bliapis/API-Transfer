using System.Threading.Tasks;

namespace Transfer.Common.Mongo
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}
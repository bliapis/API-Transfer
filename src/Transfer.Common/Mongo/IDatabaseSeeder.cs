using System.Threading.Tasks;

namespace Transfer.Common.Mongo
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();
    }
}
using Transfer.Common.Events;
using Transfer.Common.Services;

namespace Transfer.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToEvent<LancamentoCreated>()
                .Build()
                .Run();
        }
    }
}

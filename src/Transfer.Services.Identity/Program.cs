using Microsoft.AspNetCore.Hosting;
using Transfer.Common.Commands;
using Transfer.Common.Services;

namespace Transfer.Services.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToCommand<CreateLancamento>()
                .Build()
                .Run();
        }
    }
}
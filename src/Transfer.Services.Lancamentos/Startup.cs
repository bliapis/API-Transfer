using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Transfer.Common.Commands;
using Transfer.Common.Mongo;
using Transfer.Common.RabbitMq;
using Transfer.Services.Lancamentos.Domain.Repositories;
using Transfer.Services.Lancamentos.Handler;
using Transfer.Services.Lancamentos.Repositories;
using Transfer.Services.Lancamentos.Services;

namespace Transfer.Services.Lancamentos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMongoDB(Configuration);
            services.AddRabbitMq(Configuration);

            //Database
            services.AddScoped<IDatabaseSeeder, CustomMongoSeeder>();

            //Handlers to rabbit
            services.AddScoped<ICommandHandler<CreateLancamento>, CreateLancamentoHandler>();

            //B-layer Services
            services.AddScoped<ILancamentoService, LancamentoService>();

            //Repositories
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ApplicationServices.GetService<IDatabaseInitializer>().InitializeAsync();
            app.UseMvc();
        }
    }
}

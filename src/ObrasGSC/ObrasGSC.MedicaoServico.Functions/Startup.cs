
using AHS.Freshservice.Application.Mappers;
using AutoMapper;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using GSCObras.MedicaoServico.Core.Repositorios;
using GSCObras.MedicaoServico.Infra.Data;
using GSCObras.MedicaoServico.Infra.Data.Comum;
using System.Collections.Generic;
using System.IO;
using GSCObras.MedicaoServico.Core.Services;
using GSCObras.MedicaoServico.Infra.Bus;
using GSCObras.MedicaoServico.Core.ServiceBus;

[assembly: FunctionsStartup(typeof(GSCObras.MedicaoServico.Functions.Startup))]
namespace GSCObras.MedicaoServico.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile($"local.settings.json", optional: true, reloadOnChange: true)
                           .AddEnvironmentVariables()
                           .Build();
            builder.Services.AddSingleton<IConfiguration>(configuration);

            builder.Services.AddCosmosDb(configuration["CosmosDB_EndpointUrl"],
                                             configuration["CosmosDB_PrimaryKey"],
                                             configuration["CosmosDB_DatabaseName"],
                                             JsonConvert.DeserializeObject<List<ContainerInfo>>(configuration["CosmosDB_Containers"]));
            builder.Services.AddScoped<IServiceMessagesBus, ServiceMessagesBus>();
            builder.Services.AddScoped<IMedicaoOrdemServicoJanelasService, MedicaoOrdemServicoJanelasService>();
            builder.Services.AddScoped<IObraRepositorio, ObraRepositorio>();
            builder.Services.AddScoped<IMedicaoOrdemServicoPagamentoRepositorio, MedicaoOrdemServicoPagamentoRepositorio>();
            builder.Services.AddScoped<IMedicaoOrdemServicoRepositorio, MedicaoOrdemServicoRepositorio>();
            builder.Services.AddScoped<IOrdemServicoRepositorio, OrdemServicoRepositorio>();
            builder.Services.AddScoped<IObraEAPRepositorio, ObraEAPRepositorio>();
            builder.Services.AddScoped<IServicoRepositorio, ServicoRepositorio>();
            builder.Services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
            builder.Services.AddScoped<ICosmosDbSeed, CosmosDbSeed>();

            builder.Services.AddLogging(options =>
            {
                options.AddFilter("GSCObras", LogLevel.Information);
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MedicaoOrdemServicoProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

        }

    }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Transaction.Application.Interfaces;
using Transaction.Application.Services;
using Transaction.Domain;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
RegisterServices(builder.Services);
using IHost host = builder.Build();

using (IServiceScope scope = host.Services.CreateScope())
{
    ProcessCommands(scope);
}

static void ProcessCommands(IServiceScope scope)
{
    var transactionService = scope.ServiceProvider.GetRequiredService<ITransactionCommandProcessor>();
    transactionService.Process();
}

void RegisterServices(IServiceCollection services)
{
    services.AddTransient<ITransactionParser, TransactionParser>();
    services.AddTransient<ITransactionCommandProcessor, TransactionCommandProcessor>();
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
    services.AddSingleton(new JsonSerializerSettings
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy
            {
                ProcessDictionaryKeys = true,
                OverrideSpecifiedNames = true
            }
        },
        MissingMemberHandling = MissingMemberHandling.Ignore,
        NullValueHandling = NullValueHandling.Ignore,
        Formatting = Formatting.None
    });
    services.UseTransactionData();
}
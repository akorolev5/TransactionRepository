using Microsoft.Extensions.DependencyInjection;
using Transaction.Domain.Interfaces;
using Transaction.Domain.Repositories;

namespace Transaction.Domain;

public static class Usage
{
    public static void UseTransactionData(this IServiceCollection services)
    {
        services.AddSingleton<ITransactionRepository, InMemoryTransactionRepository>();
    }
}

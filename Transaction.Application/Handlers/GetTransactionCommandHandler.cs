using MediatR;
using Newtonsoft.Json;
using Transaction.Application.Commands;
using Transaction.Domain.Exception;
using Transaction.Domain.Interfaces;

namespace Transaction.Application.Handlers;

public class GetTransactionCommandHandler : IRequestHandler<GetTransactionCommand>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly JsonSerializerSettings _jsonSerializerSettings;

    public GetTransactionCommandHandler(ITransactionRepository transactionRepository, JsonSerializerSettings jsonSerializerSettings)
    {
        _transactionRepository = transactionRepository;
        _jsonSerializerSettings = jsonSerializerSettings;
    }

    public Task Handle(GetTransactionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var transaction = _transactionRepository.Get(request.TransactionId);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Найдена следующая тарнзакция с Id={0}", request.TransactionId);
            Console.WriteLine("{0}{1}", JsonConvert.SerializeObject(transaction, _jsonSerializerSettings), Environment.NewLine);
        }
        catch (TransactionNotFindedException notFindedException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}{1}", notFindedException.Message, Environment.NewLine);
        }
        catch (Exception getException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}{1}", getException.Message, Environment.NewLine);
        }
        return Task.FromResult(request);
    }
}

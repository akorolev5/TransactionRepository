using MediatR;
using Transaction.Application.Commands;
using Transaction.Domain.Exception;
using Transaction.Domain.Interfaces;

namespace Transaction.Application.Handlers;

public class AddTransactionCommandHandler : IRequestHandler<AddTransactionCommand>
{
    private readonly ITransactionRepository _transactionRepository;

    public AddTransactionCommandHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public Task Handle(AddTransactionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _transactionRepository.Add(new Domain.Model.Transaction
            {
                Id = request.TransactionId,
                TransactionDate = request.TransactionDateTime,
                Amount = request.Amount
            });
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Транзация с id = {0} успешно добавлена в хранилище{1}", request.TransactionId, Environment.NewLine);
        }
        catch (TransactionAlreadyExistException existException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}{1}", existException.Message, Environment.NewLine);
        }
        catch (Exception addException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}{1}", addException.Message, Environment.NewLine);
        }
        return Task.FromResult(request);
    }
}
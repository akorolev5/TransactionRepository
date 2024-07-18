using MediatR;

namespace Transaction.Application.Commands;

public class AddTransactionCommand : IRequest
{
    public int TransactionId
    {
        get { return _transactionId; }
    }
    
    public DateTime TransactionDateTime
    {
        get { return _transactionDateTime; }
    }

    public decimal Amount
    {
        get { return _amount; }
    }

    private readonly int _transactionId;
    private readonly DateTime _transactionDateTime;
    private readonly decimal _amount;

    public AddTransactionCommand(int transactionId, DateTime transactionDateTime, decimal amount)
    {
        _transactionId = transactionId;
        _transactionDateTime = transactionDateTime;
        _amount = amount;
    }
}
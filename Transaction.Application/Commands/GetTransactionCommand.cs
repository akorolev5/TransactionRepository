using MediatR;

namespace Transaction.Application.Commands;

public class GetTransactionCommand : IRequest
{
    public int TransactionId
    {
        get { return transactionId; }
    }
    private readonly int transactionId;


    public GetTransactionCommand(int transactionId)
    {
        this.transactionId = transactionId;
    }
}
namespace Transaction.Domain.Exception;

public class TransactionNotFindedException : System.Exception
{
    private const string _notFoundExceptionMessage = "Не найдена транзакция по запрошенному id={0}";

    public TransactionNotFindedException(int transactionId) : base(string.Format(_notFoundExceptionMessage, transactionId))
    {
    }
}
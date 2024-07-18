namespace Transaction.Domain.Exception;

public class TransactionAlreadyExistException : System.Exception
{
    private const string _alreadyExistExceptionMessage = "Транзакция с указанным id {0} уже существует";

    public TransactionAlreadyExistException(Model.Transaction transaction) : base(string.Format(_alreadyExistExceptionMessage, transaction.Id))
    {
    }
}

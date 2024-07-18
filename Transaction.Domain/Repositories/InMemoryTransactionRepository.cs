using Transaction.Domain.Exception;
using Transaction.Domain.Interfaces;

namespace Transaction.Domain.Repositories;

public class InMemoryTransactionRepository : ITransactionRepository
{
    /// <summary>
    /// Можно сделать ConcurrentDictionary, чтобы обеспечить доступ к словарю нескольких потоков
    /// </summary>
    private readonly Dictionary<int, Model.Transaction> _transactions;

    public InMemoryTransactionRepository()
    {
        _transactions = new Dictionary<int, Model.Transaction>();
    }
    
    public void Add(Model.Transaction transaction)
    {
        if (_transactions.TryGetValue(transaction.Id, out Model.Transaction? targetTransaction))
        {
            throw new TransactionAlreadyExistException(transaction);
        }
        _transactions.Add(transaction.Id, transaction);
    }

    public Model.Transaction Get(int transactionId)
    {
        if (_transactions.TryGetValue(transactionId, out Model.Transaction? result))
        {
            return result;
        }
        else
        {
            throw new TransactionNotFindedException(transactionId);
        }
    }
}

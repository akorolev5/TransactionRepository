namespace Transaction.Domain.Interfaces;

public interface ITransactionRepository
{
    public void Add(Model.Transaction transaction);

    public Model.Transaction Get(int transactionId);
}
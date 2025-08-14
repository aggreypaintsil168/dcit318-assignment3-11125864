using FinanceSystem.Models;

namespace FinanceSystem.Processors
{
    public interface ITransactionProcessor
    {
        void Process(Transaction transaction);
    }
}

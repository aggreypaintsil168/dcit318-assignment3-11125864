using System;
using FinanceSystem.Models;

namespace FinanceSystem.Processors
{
    public class BankTransferProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Bank Transfer of {transaction.Amount} for {transaction.Category}");
        }
    }
}

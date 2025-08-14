using System;
using FinanceSystem.Models;

namespace FinanceSystem.Processors
{
    public class MobileMoneyProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Mobile Money payment of {transaction.Amount} for {transaction.Category}");
        }
    }
}

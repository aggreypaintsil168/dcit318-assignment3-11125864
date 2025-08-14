using System;
using FinanceSystem.Models;

namespace FinanceSystem.Processors
{
    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Crypto Wallet used for {transaction.Amount} spent on {transaction.Category}");
        }
    }
}

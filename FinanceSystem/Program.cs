using System;
using System.Collections.Generic;
using FinanceSystem.Models;
using FinanceSystem.Processors;

namespace FinanceSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var transactions = new List<Transaction>();

            var account = new SavingsAccount("ACC123", 1000m);

            var t1 = new Transaction(1, DateTime.Now, 150m, "Groceries");
            var t2 = new Transaction(2, DateTime.Now, 300m, "Utilities");
            var t3 = new Transaction(3, DateTime.Now, 800m, "Entertainment");

            var mobileProcessor = new MobileMoneyProcessor();
            var bankProcessor = new BankTransferProcessor();
            var cryptoProcessor = new CryptoWalletProcessor();

            mobileProcessor.Process(t1);
            bankProcessor.Process(t2);
            cryptoProcessor.Process(t3);

            account.ApplyTransaction(t1);
            account.ApplyTransaction(t2);
            account.ApplyTransaction(t3);

            transactions.Add(t1);
            transactions.Add(t2);
            transactions.Add(t3);

            Console.WriteLine($"Total transactions stored: {transactions.Count}");
        }
    }
}

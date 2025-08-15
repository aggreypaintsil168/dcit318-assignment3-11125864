
using System;
using System.Collections.Generic;
using FinanceSystem.Models;
using FinanceSystem.Processors;

namespace FinanceSystem
{
    public class FinanceApp
    {
        private List<Transaction> _transactions = new List<Transaction>();

        public void Run()
        {
            // 1. Create SavingsAccount
            var account = new SavingsAccount("ACC123", 1000m);

            // 2. Create Transactions
            var t1 = new Transaction(1, DateTime.Now, 150m, "Groceries");
            var t2 = new Transaction(2, DateTime.Now, 300m, "Utilities");
            var t3 = new Transaction(3, DateTime.Now, 800m, "Entertainment");

            // 3. Create Processors
            var mobileProcessor = new MobileMoneyProcessor();
            var bankProcessor = new BankTransferProcessor();
            var cryptoProcessor = new CryptoWalletProcessor();

            // 4. Process Transactions
            mobileProcessor.Process(t1);
            bankProcessor.Process(t2);
            cryptoProcessor.Process(t3);

            // 5. Apply Transactions to Account
            account.ApplyTransaction(t1);
            account.ApplyTransaction(t2);
            account.ApplyTransaction(t3);

            // 6. Store Transactions
            _transactions.Add(t1);
            _transactions.Add(t2);
            _transactions.Add(t3);

            // 7. Display summary
            Console.WriteLine($"Total transactions stored: {_transactions.Count}");
        }
    }
}



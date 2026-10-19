using System;
using System.Collections.Generic;
using System.Linq;

namespace BackendLearning
{
    public class AccountManager : IAccountService
    {
        private readonly List<BankAccount> _accounts = new List<BankAccount>();

        public BankAccount? FindAccountByNumber(string AccountNumber)
        {
            return _accounts.FirstOrDefault(a => a.AccountNumber.Equals(AccountNumber, StringComparison.OrdinalIgnoreCase));
        }

        public bool CreateSavingsAccount(string AccountNumber, string AccountName, decimal initialBalance)
        {
            if (FindAccountByNumber(AccountNumber) != null)
            {
                Console.WriteLine($"ERROR: Account number '{AccountNumber}' already exists.");
                return false;
            }
            var newAccount = new SavingsAccount(AccountNumber, AccountName, initialBalance);

            _accounts.Add(newAccount);
            Console.WriteLine($"Congratulations: {AccountName}, your Savings Account is ready");
            return true;
        }

        public bool CreateCurrentAccount(string AccountNumber, string AccountName, decimal initialBalance)
        {
            if (FindAccountByNumber(AccountNumber) != null)
            {
                Console.WriteLine($"ERROR: Account number '{AccountNumber}' already exists.");
                return false;
            }
            var newAccount = new CurrentAccount(AccountNumber, AccountName, initialBalance);

            _accounts.Add(newAccount);
            Console.WriteLine($"Congratulations: {AccountName}, your Current Account is ready");
            return true;
        }

        public bool Deposit(string AccountNumber, decimal amount)
        {
            var account = FindAccountByNumber(AccountNumber);

            if (account != null)
            {
                account.Deposit(amount);
                return true;
            }
            Console.WriteLine($"Account not found");
            return false;
        }

        public bool Withdraw(string AccountNumber, decimal amount)
        {
            var account = FindAccountByNumber(AccountNumber);

            if (account != null)
            {
                account.Withdraw(amount);
                return true;
            }
            Console.WriteLine($"Account not found");
            return false;
        }

        public List<BankAccount> GetAllAccounts()
        {
            return _accounts;
        }
    }
}
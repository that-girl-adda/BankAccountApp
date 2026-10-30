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
            Console.WriteLine("Entered CreateSavingsAccount.");

            if (FindAccountByNumber(AccountNumber) != null)
            {
                Console.WriteLine(
                    $"ERROR: Account number '{AccountNumber}' already exists.");

                return false;
            }

            Console.WriteLine(" No duplicate account found.");

            var newAccount = new SavingsAccount(
                AccountNumber, AccountName, initialBalance);

            Console.WriteLine("SavingsAccount object created.");

            _accounts.Add(newAccount);

            Console.WriteLine(" Account added to collection.");

            newAccount.AccountType();

            Console.WriteLine(" AccountType method completed.");

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


            newAccount.AccountType();

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
            throw new AccountNotFoundException($"Error: Account number '{AccountNumber}' could not be found.");


        }

        public bool Withdraw(string AccountNumber, decimal amount)
        {
            var account = FindAccountByNumber(AccountNumber);

            if (account != null)
            {
                account.Withdraw(amount);
                return true;
            }
            throw new AccountNotFoundException($"Error: Account number '{AccountNumber}' could not be found.");

        }

        public List<BankAccount> GetAllAccounts()
        {
            return _accounts;
        }


        public List<BankAccount> GetAccountsAbove100k()
        {
            return _accounts.Where(a => a.Balance > 100000).ToList();
        }


        public List<SavingsAccount> GetSavingsAccounts()
        {
            return _accounts.OfType<SavingsAccount>().ToList();
        }


        public List<CurrentAccount> GetCurrentAccounts()
        {
            return _accounts.OfType<CurrentAccount>().ToList();
        }


        public decimal GetTotalBalance()
        {
            return _accounts.Sum(a => a.Balance);
        }


        public BankAccount? GetAccountWithHighestBalance()
        {
            return _accounts.OrderByDescending(a => a.Balance).FirstOrDefault();
        }


    }
}

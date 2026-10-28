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
            Console.WriteLine("[DEBUG 1] Entered CreateSavingsAccount.");

            if (FindAccountByNumber(AccountNumber) != null)
            {
                Console.WriteLine(
                    $"ERROR: Account number '{AccountNumber}' already exists.");

                return false;
            }

            Console.WriteLine("[DEBUG 2] No duplicate account found.");

            var newAccount = new SavingsAccount(
                AccountNumber, AccountName, initialBalance);

            Console.WriteLine("[DEBUG 3] SavingsAccount object created.");

            _accounts.Add(newAccount);

            Console.WriteLine("[DEBUG 4] Account added to collection.");

            newAccount.AccountType();

            Console.WriteLine("[DEBUG 5] AccountType method completed.");

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
            
            // Trigger your custom polymorphic account type message!
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

        public List <BankAccount> GetAllAccounts()
        {
            return _accounts;
        }
    }
}
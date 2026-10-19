namespace BackendLearning
{
            public interface IAccountService
        {
            bool CreateSavingsAccount(string AccountNumber, string AccountName, decimal initialBalance);
            bool CreateCurrentAccount(string AccountNumber, string AccountName, decimal initialBalance);
            BankAccount ? FindAccountByNumber(string AccountNumber);
            bool Deposit(string AccountNumber, decimal amount);
            bool Withdraw(string AccountNumber, decimal amount);
            List<BankAccount> GetAllAccounts();

        }
}
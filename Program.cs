namespace BackendLearning
{
    public class Program
    {
        public static void Main(string[] args)
        {


            IAccountService accountService = new AccountManager();
            bool running = true; 

            Console.WriteLine("===WELCOME TO THE BANK ACCOUNT MANAGEMENT SYSTEM==");

            while(running)
            {
                Console.WriteLine("\n===Please select an option:===");
                Console.WriteLine("1.  Create savings account");
                Console.WriteLine("2.  Create current account");
                Console.WriteLine("3.  Deposit money");
                Console.WriteLine("4.  Withdraw money");
                Console.WriteLine("5.  View all accounts");
                Console.WriteLine("6.  Check account balance");
                Console.WriteLine("7.  View accounts with balance > ₦100,000"); 
                Console.WriteLine("8.  View savings accounts");                 
                Console.WriteLine("9.  View current accounts");                 
                Console.WriteLine("10. Display total balance of all accounts");
                Console.WriteLine("11. Display account with highest balance");
                Console.WriteLine("12. Exit");
                Console.WriteLine("Enter your choice (1-12):");

                string? choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        CreateSavings(accountService); 
                        break;
                    case "2":
                        CreateCurrent(accountService); 
                        break;
                    case "3":
                        DepositMoney(accountService);
                        break;
                    case "4":
                        WithdrawMoney(accountService);
                        break;
                    case "5":
                        ViewAllAccounts(accountService);
                        break;
                    case "6":
                        CheckBalance(accountService);
                        break;
                    case "7":
                        GetAccountsAbove100k(accountService);
                        break;

                    case "8":
                        GetSavingsAccount(accountService);
                        break;

                    case "9":
                        GetCurrentAccount(accountService);
                        break;

                    case "10":
                        GetTotalBalance(accountService);
                        break;

                    case "11":
                        GetAccountWithHighestAccountBalance(accountService);
                           break;
                    case "12":
                        running = false;
                        Console.WriteLine("Thank you for banking with us. Goodbye!");
                        break;   
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid number between 1 and 7");
                        break;
                }
            }

           

        }
       private static void CreateSavings(IAccountService service)
        {
            Console.Write("Enter Account Number: ");
            string? accNumber = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(accNumber))
            {
                Console.WriteLine("Error: Account Number cannot be blank");
                return;
            }

            if(service.FindAccountByNumber(accNumber) != null)
            {
                Console.WriteLine("Error: Account Number must be unique.This number already exists");
                    return;
            }
            
            Console.Write("Enter Account Name: ");
            string? accName = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(accName))
            {
                Console.WriteLine("Error: Account Name cannot be blank");
                return;
            }

            Console.Write("Enter Initial Balance: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal balance) || balance < 0)
            {
                Console.WriteLine("Invalid numeric input. Please enter a valid number.");
                return;
            }

            if (string.IsNullOrWhiteSpace(accName))
            {
                Console.WriteLine("Error: Account Name cannot be blank");
                return;
            }

            try
            {
                Console.WriteLine("[DEBUG] Calling AccountManager...");

                bool created = service.CreateSavingsAccount(
                    accNumber, accName, balance);

                Console.WriteLine($"[DEBUG] Creation result: {created}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex}");
            }
        }

        private static void CreateCurrent(IAccountService service)
        {
            Console.Write("Enter Account Number: ");
            string? accNumber = Console.ReadLine()?.Trim();
           if (string.IsNullOrWhiteSpace(accNumber))
            {
                Console.WriteLine("Error: Account Number cannot be blank");
                return;
            }

           if (service.FindAccountByNumber(accNumber)!= null)
            {
                Console.WriteLine("Error: Account Number must be unique. This number already exists");
                return;
            }

            Console.Write("Enter Account Name: ");
            string? accName = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(accName))
            {
                Console.WriteLine("Error: Account Name cannot be blank");
                return;
            }

            Console.Write("Enter Initial Balance: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal balance) || balance < 0)
            {
                Console.WriteLine("Invalid numeric input or balance cannot be negative ");
                return;
            }

            try
            {
                Console.WriteLine("[DEBUG] Calling AccountManager...");

                bool created = service.CreateCurrentAccount(
                    accNumber, accName, balance);

                Console.WriteLine($"[DEBUG] Creation result: {created}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex}");
            }
 
        }



        private static void DepositMoney(IAccountService service)
        {
            Console.Write("Enter Account Number:  ");
            string? accNumber = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(accNumber))
            {
                Console.WriteLine("Error: Account Number cannot be blank");
                return;
            }

            var account = service.FindAccountByNumber(accNumber);
            if (account == null)
            {
                Console.WriteLine("Error: Account not found!");
                return; 
            }

            Console.Write("Enter Amount to Deposit:  ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount<= 0)
            {
                Console.WriteLine("Error: Invalid numeric input or deposit amount must be greater than zero.");
                return;
            }

            try
            {
                service.Deposit(accNumber, amount);
                Console.WriteLine($"Successfully deposited ₦{amount:N2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
            }
        }

        private static void WithdrawMoney(IAccountService service)
        {
            Console.Write("Enter Account Number:  ");
            string? accNumber = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(accNumber))
            {
                Console.WriteLine("Error: Account Number cannot be blank");
                return;
            }

            Console.Write("Enter Amount to Withdraw: ");
            if(!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("Invalid numeric input or withdrawal amount must be greater than zero.");
                return;
            }

            try
            {
                service.Withdraw(accNumber, amount);
                Console.WriteLine("Withdrawal successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex}");
            }

        }

        private static void ViewAllAccounts(IAccountService service)
        {
            var accounts = service.GetAllAccounts();
        if (accounts.Count == 0)
            {
                Console.WriteLine("No Accounts found in the system.");
                return;
            }

            Console.WriteLine("\n=======ALL REGISTERED ACCOUNTS ======");
            foreach (var acc in accounts)
            {
                acc.DisplayAccountDetails();
            }
        }
        
        private static void CheckBalance(IAccountService service)
        {
            Console.Write("Enter Account Number: ");
            string? accNumber = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(accNumber))
            {
                Console.WriteLine("Error: AccountNumber cannot be blank");
                return;
            }
            try
            {

                var account = service.FindAccountByNumber(accNumber);

                if (account == null)
                {
                    Console.WriteLine("Error: Account not found.");
                    return;
                }


                Console.WriteLine("\n=== Account Details ===");
                Console.WriteLine($"Account Number: {account.AccountNumber}");
                Console.WriteLine($"Account Name:   {account.AccountName}");
                Console.WriteLine($"Current Balance: ₦{account.GetBalance():N2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex}");
            }
        }

        private static void GetAccountsAbove100k(IAccountService service)
        {
            var highAccounts = service.GetAccountsAbove100k();
            if (!highAccounts.Any())
            {
                Console.WriteLine("[INFO] No accounts found with a balance above ₦100,000.");
            }
            else
            {
                Console.WriteLine("\n--- Accounts with Balance > ₦100,000 ---");
                foreach (var acc in highAccounts)
                {
                    Console.WriteLine($"Acc No: {acc.AccountNumber} | Name: {acc.AccountName} | Balance: ₦{acc.Balance:N2}");
                }
            }
        }

        private static void GetSavingsAccount(IAccountService service)
        {
            var savings = service.GetSavingsAccounts();
            if (!savings.Any())
            {
                Console.WriteLine("[INFO] No savings accounts found.");
            }
            else
            {
                Console.WriteLine("\n--- Savings Accounts ---");
                foreach (var acc in savings)
                {
                    Console.WriteLine($"Acc No: {acc.AccountNumber} | Name: {acc.AccountName} | Balance: ₦{acc.Balance:N2}");
                }
            }
        }

        private static void GetCurrentAccount(IAccountService service)
        {
            var current = service.GetCurrentAccounts();
            if (!current.Any())
            {
                Console.WriteLine("[INFO] No current accounts found.");
            }
            else
            {
                Console.WriteLine("\n--- Current Accounts ---");
                foreach (var acc in current)
                {
                    Console.WriteLine($"Acc No: {acc.AccountNumber} | Name: {acc.AccountName} | Balance: ₦{acc.Balance:N2}");
                }
            }
        }

        private static void GetTotalBalance(IAccountService service)
        {
            decimal total = service.GetTotalBalance();
            Console.WriteLine($"\n[INFO] Total balance across all accounts: ₦{total:N2}");
        }

        private static void GetAccountWithHighestAccountBalance(IAccountService service)
        {
            var topAccount = service.GetAccountWithHighestBalance();
            if (topAccount == null)
            {
                Console.WriteLine("[INFO] No accounts exist in the system yet.");
            }
            else
            {
                Console.WriteLine("\n--- Account with Highest Balance ---");
                Console.WriteLine($"Acc No: {topAccount.AccountNumber} | Name: {topAccount.AccountName} | Balance: ₦{topAccount.Balance:N2}");
            }

        }




    }
}
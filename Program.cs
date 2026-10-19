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
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Create Savings Account");
                Console.WriteLine("2. Create Current Account");
                Console.WriteLine("3. Deposit Money");
                Console.WriteLine("4. Withdraw Money");
                Console.WriteLine("5. View All Accounts");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter your choice (1-6):");

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
                        running = false;
                        Console.WriteLine("Thank you for banking with us. Goodbye!");
                        break;   
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid number between 1 and 6 ");
                        break;
                }
            }

           




            
             

        }
        private static void CreateSavings(IAccountService service)
        {
            Console.Write("Enter Account Number: ");
            string? accNumber = Console.ReadLine();

            Console.Write("Enter Account Name: ");
            string? accName = Console.ReadLine();

            Console.Write("Enter Initial Deposit:n");
            decimal.TryParse(Console.ReadLine(), out decimal balance);

            if (string.IsNullOrEmpty(accNumber) || string.IsNullOrEmpty(accName))
            {
                Console.WriteLine("Error: Account Number and Account Name cannot be blank");
                return;
            }
            service.CreateSavingsAccount(accNumber, accName, balance);
        }

        private static void CreateCurrent(IAccountService service)
        {
            Console.Write("Enter Account Number: ");
            string? accNumber = Console.ReadLine();

            Console.Write("Enter Account Name: ");
            string? accName = Console.ReadLine();

            Console.Write("Enter Initial Deposit: ");
            decimal.TryParse(Console.ReadLine(), out decimal balance);

            if (string.IsNullOrEmpty(accNumber) || string.IsNullOrEmpty(accName))
            {
                Console.WriteLine("Error: Account Number and Account Name cannot be blank");
                return;
            }
            service.CreateCurrentAccount(accNumber, accName, balance);
        }

        private static void DepositMoney(IAccountService service)
        {
            Console.Write("Enter Account Number:  ");
            string? accNumber = Console.ReadLine();

            Console.Write("Enter Amount to Deposit:  ");
            decimal.TryParse(Console.ReadLine(), out decimal amount);

            if (string.IsNullOrEmpty(accNumber))
            {
                Console.WriteLine("Error: Account Number cannot be blank");
                return;
            }
            service.Deposit(accNumber, amount);
        }

        private static void WithdrawMoney(IAccountService service)
        {
            Console.Write("Enter Account Number:  ");
            string? accNumber = Console.ReadLine();

            Console.Write("Enter Amount to Withdraw: ");
            decimal.TryParse(Console.ReadLine(), out decimal amount);

            if (string.IsNullOrEmpty(accNumber))
            {
                Console.WriteLine("Error: Account Number cannot be blank");
                return;
            }
            service.Deposit(accNumber, amount);
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


    }
}
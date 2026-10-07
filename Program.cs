namespace BackendLearning
{
    public class Program
    {
        public static void Main()
        {
            BankAccount johnsAccount = new BankAccount("001", "John", 50000);

            johnsAccount.DisplayAccountDetails();
             
            Console.WriteLine("\n=== VALID TRANSACTIONS ===");
            johnsAccount.Deposit(20000m);
            Console.WriteLine($" GetBalance : N{johnsAccount.GetBalance():N2}");

            johnsAccount.Withdraw(15000m);
            Console.WriteLine($"Balance: N{johnsAccount.GetBalance():N2}");



            Console.WriteLine("\n=== TESTING INVALID CASES ===");
            johnsAccount.Deposit(0m);
            johnsAccount.Deposit(-5000m);
            johnsAccount.Withdraw(0m);
            johnsAccount.Withdraw(-2000m);
            johnsAccount.Withdraw(100000m);


            
            Console.WriteLine("\n=== FINAL STATE ===");
            johnsAccount.DisplayAccountDetails();



            Console.WriteLine("             SAVINGS ACCOUNT TESTS                ");

            SavingsAccount adasAccount = new SavingsAccount("SAV-002", "Ada", 30000m);
            adasAccount.AccountType();

             Console.WriteLine("\n--- Valid Withdrawal (₦10,000 from ₦30,000) ---");
             adasAccount.Withdraw(20000m);
            Console.WriteLine($"Current Balance: N{adasAccount.GetBalance():N2}");

            Console.WriteLine("\n--- Withdrawal Below ₦5,000 Limit (₦7,000 from ₦10,000) ---");
            adasAccount.Withdraw(7000m);
            Console.WriteLine($"Current Balance: N{adasAccount.GetBalance():N2}");

            Console.WriteLine("\n--- Negative Withdrawal (-₦2,000) ---");
            adasAccount.Withdraw(-2000m);

            Console.WriteLine("\n--- Zero Withdrawal (₦0) ---");
            adasAccount.Withdraw(0m);



            Console.WriteLine("             CURRENT ACCOUNT TESTS                ");
            Console.WriteLine("==================================================");

            CurrentAccount miriamsAccount = new CurrentAccount("CUR-003", "Miriam", 20000m);
            miriamsAccount.AccountType();

            Console.WriteLine("\n--- Normal Withdrawal (₦10,000 from ₦20,000) ---");
            miriamsAccount.Withdraw(10000m);
            Console.WriteLine($"Current Balance: N{miriamsAccount.GetBalance():N2}");

            Console.WriteLine("\n--- Withdrawal Using Overdraft (₦40,000 from ₦10,000) ---");
            miriamsAccount.Withdraw(40000m);
            Console.WriteLine($"Current Balance: N{miriamsAccount.GetBalance():N2}");

            Console.WriteLine("\n--- Exceeding ₦50,000 Overdraft Limit (₦30,000 when balance is -₦30,000) ---");
            miriamsAccount.Withdraw(30000m);
            Console.WriteLine($"Current Balance: N{miriamsAccount.GetBalance():N2}");

            Console.WriteLine("          POLYMORPHISM DEMONSTRATION             ");
            Console.WriteLine("==================================================");


            List<BankAccount> myAccounts = new List<BankAccount>();


            myAccounts.Add(new BankAccount("001", "John", 50000m));
            myAccounts.Add(new SavingsAccount("002", "Ada", 20000m));
            myAccounts.Add(new CurrentAccount("003", "Miriam", 15000m));


            foreach (BankAccount acc in myAccounts)
            {
            Console.WriteLine($"\nAccount: {acc.AccountName}");
            acc.Withdraw(18000m);
}
        }






            
             

        
    }
}
namespace BackendLearning
{
    public class Program
    {
        public static void Main()
        {
            BankAccount bnkAccount = new BankAccount("001", "John", 50000);

            bnkAccount.DisplayAccountDetails();
             
            Console.WriteLine("\n=== VALID TRANSACTIONS ===");
            bnkAccount.Deposit(20000m);
            Console.WriteLine($" GetBalance : N{bnkAccount.GetBalance():N2}");

            bnkAccount.Withdraw(15000m);
            Console.WriteLine($"Balance: N{bnkAccount.GetBalance():N2}");



            Console.WriteLine("\n=== TESTING INVALID CASES ===");
            bnkAccount.Deposit(0m);
            bnkAccount.Deposit(-5000m);
            bnkAccount.Withdraw(0m);
            bnkAccount.Withdraw(-2000m);
            bnkAccount.Withdraw(100000m);


            
            Console.WriteLine("\n=== FINAL STATE ===");
            bnkAccount.DisplayAccountDetails();



            Console.WriteLine("             SAVINGS ACCOUNT TESTS                ");

            SavingsAccount savAccount = new SavingsAccount("SAV-002", "Ada", 30000m);
            savAccount.AccountType();
              
            savAccount.DisplayAccountDetails();

            Console.WriteLine("\n--- Valid Withdrawal (₦10,000 from ₦30,000) ---");
            savAccount.Withdraw(20000m);
            Console.WriteLine($"Current Balance: N{savAccount.GetBalance():N2}");

            Console.WriteLine("\n--- Withdrawal Below ₦5,000 Limit (₦7,000 from ₦10,000) ---");
            savAccount.Withdraw(7000m);
            Console.WriteLine($"Current Balance: N{savAccount.GetBalance():N2}");

            Console.WriteLine("\n--- Negative Withdrawal (-₦2,000) ---");
            savAccount.Withdraw(-2000m);

            Console.WriteLine("\n--- Zero Withdrawal (₦0) ---");
            savAccount.Withdraw(0m);



            Console.WriteLine("             CURRENT ACCOUNT TESTS                ");
            Console.WriteLine("==================================================");

            CurrentAccount curAccount = new CurrentAccount("CUR-003", "Miriam", 20000m);
            curAccount.AccountType();
            
            curAccount.DisplayAccountDetails();

            Console.WriteLine("\n--- Normal Withdrawal (₦10,000 from ₦20,000) ---");
            curAccount.Withdraw(10000m);
            Console.WriteLine($"Current Balance: N{curAccount.GetBalance():N2}");

            Console.WriteLine("\n--- Withdrawal Using Overdraft (₦40,000 from ₦10,000) ---");
            curAccount.Withdraw(40000m);
            Console.WriteLine($"Current Balance: N{curAccount.GetBalance():N2}");

            Console.WriteLine("\n--- Exceeding ₦50,000 Overdraft Limit (₦30,000 when balance is -₦30,000) ---");
            curAccount.Withdraw(30000m);
            Console.WriteLine($"Current Balance: N{curAccount.GetBalance():N2}");

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
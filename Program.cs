namespace BackendLearning
{
    public class Program
    {
        public static void Main()
        {
            BankAccount johnsAccount = new BankAccount("001", "John", 50000);

            johnsAccount.DisplayAccountDetails();
             
            Console.WriteLine("\n=== VALISD TRANSACTIONS ===");
            johnsAccount.Deposit(20000m);
            Console.WriteLine($"GetBalance() : N{johnsAccount.GetBalance() : N2}");

            johnsAccount.Withdraw(15000m);
            Console.WriteLine($"GetBalance(): N{johnsAccount.GetBalance():N2}");



            Console.WriteLine("\n=== TESTING INVALID CASES ===");
            johnsAccount.Deposit(0m);
            johnsAccount.Deposit(-5000m);
            johnsAccount.Withdraw(0m);
            johnsAccount.Withdraw(-2000m);
            johnsAccount.Withdraw(100000m);



            
            Console.WriteLine("\n=== FINAL STATE ===");
            johnsAccount.DisplayAccountDetails();
             

        }
    }
}
namespace BackendLearning
{
    public class BankAccount
    {
        public string AccountNumber{get;}
        public string AccountName  {get; set;}
        public decimal Balance {get; private set;}

        public BankAccount(string accNumber, string accName, decimal balance)
        {
            AccountNumber = accNumber;
            AccountName = accName;
            Balance = balance >= 0 ? balance : 0;
        }

        public void Deposit (decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine($"Deposit failed: N{amount:N2} is an invalid amount. Deposit must be greater than zero. ");
                return;
            }
            Balance += amount;
            Console.WriteLine($"Sucessfully deposited N{amount:N2}. New Balance: N{Balance:N2}");
        }
        public void Withdraw (decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine($"[ERROR] Enter valid amount");
                return;
            }
            if (amount > Balance)
            {
                Console.WriteLine($"[ERROR] Insuffiecinet funds. You tried to withdraw N{amount:N2}, but your balance is only N{Balance:N2}.");
                return;
            }
            Balance -= amount;
            Console.WriteLine($"Your Withdrawal of N{amount:N2} was successful. New balance: N{Balance:N2} ");
        }

        public decimal GetBalance()
        {
            return Balance;
        }

        public void DisplayAccountDetails ()
        {
            Console.WriteLine("Account Details");
            Console.WriteLine($"Account Number : {AccountNumber}");
            Console.WriteLine($"Account Name    : {AccountName}"); 
            Console.WriteLine($"Current Balance : N{Balance:N2}");
            Console.WriteLine("...............");
        }
        
        
    }

}


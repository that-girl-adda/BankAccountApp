namespace BackendLearning
{
    public class BankAccount
    {
        public string AccountNumber{get;}
        public string AccountName  {get; set;}
        private  decimal _balance ;

        protected decimal Balance
        {
            get => _balance;
            set => _balance = value;
        }

        public BankAccount(string accNumber, string accName, decimal initialBalance)
        {
            AccountNumber = accNumber;
            AccountName = accName;
            _balance= initialBalance >= 0 ? initialBalance: 0;
        }

        public void Deposit (decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine($"Deposit failed: N{amount:N2} is an invalid amount. Deposit must be greater than zero. ");
                return;
            }
            _balance += amount;
            Console.WriteLine($"Sucessfully deposited N{amount:N2}. New Balance: N{_balance:N2}");
        }
        public virtual void Withdraw (decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine($"[ERROR] Enter valid amount");
                return;
            }
            if (amount > _balance)
            {
                Console.WriteLine($"[ERROR] Insufficient funds. You tried to withdraw N{amount:N2}, but your balance is only N{_balance:N2}.");
                return;
            }
            _balance -= amount;
            Console.WriteLine($"Your Withdrawal of N{amount:N2} was successful. New balance: N{_balance:N2} ");
        }

        public decimal GetBalance()
        {
            return _balance;
        }


        public void DisplayAccountDetails ()
        {
            Console.WriteLine("Account Details");
            Console.WriteLine($"Account Number : {AccountNumber}");
            Console.WriteLine($"Account Name    : {AccountName}"); 
            Console.WriteLine($"Current Balance : N{_balance:N2}");
            Console.WriteLine("...............");
        }

        public virtual void AccountType()
        {
            Console.WriteLine($" Hello, {AccountName}. You can open a savings or current account!!");
        
        }

            
    }    

}



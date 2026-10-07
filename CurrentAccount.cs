namespace BackendLearning
{
        public class CurrentAccount : BankAccount
    {
        private  readonly decimal _overdraftLimit = 50000m;
        public CurrentAccount(string accNumber, string accName,  decimal initialBalance): base( accNumber,  accName,   initialBalance)
        {
 
        }
        public override void AccountType()
        {
            Console.WriteLine($"[Successful] {AccountName}, Your Current account is on its way ");
        }
        public override void Withdraw(decimal amount)
        {

            if (amount <= 0)
            {
                Console.WriteLine("[ERROR] Enter valid amount");
                return;
            }

            if (Balance - amount < -_overdraftLimit)
            {
                Console.WriteLine($"[ERROR] Withdrawal denied, Overdraft limit exceeded! You can only withdraw up to N{(Balance+_overdraftLimit):N2}");
                return;
            } 

            Balance -= amount;
            Console.WriteLine($"[Successful] Withdrawal of N{amount:N2} completed. New balance: N{Balance:N2} ");
        }

    }
}
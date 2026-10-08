namespace BackendLearning
{
        public class SavingsAccount : BankAccount
    {
        private  readonly decimal _fixedBalance = 5000m;
        public SavingsAccount(string accNumber, string accName,  decimal initialBalance): base( accNumber,  accName,   initialBalance)
        {
 
        }
        public override void AccountType()
        {
            Console.WriteLine($" Hello {AccountName}, your savings account is on its way... ");
            Console.WriteLine($"=================== PROCESSING ====================== ");
            Console.WriteLine($"[Congratulations] {AccountName}, your savings account is ready!! ");
        }


        public override void DisplayAccountDetails ()
        {
            base.DisplayAccountDetails(); 
            Console.WriteLine($"Account Type    : Savings Account (Min Balance: N{_fixedBalance:N2})");
            Console.WriteLine("...............");
                    
        }
        
        public override void Withdraw(decimal amount)
        {
             if (amount <= 0)
            {
                base.Withdraw(amount);
                return;
            }

            if (Balance - amount < _fixedBalance)
            {
                Console.WriteLine($"[ERROR] Withdrawal denied, You can only withdraw N{(Balance -_fixedBalance):N2}. Account limit is N{_fixedBalance:N2} ");
                return;
            } 

            base.Withdraw(amount);
        }

    }
}
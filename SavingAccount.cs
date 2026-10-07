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
            Console.WriteLine($"[Successful] {AccountName}, Your Savings account is on its way ");
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
namespace Banking.Domain
{
    public class BankAccount
    {
        private decimal _balance = 5000M;

        public void Deposit(decimal amountToDeposit)
        {
            _balance += amountToDeposit;
        }

        public decimal GetBalance()
        {
            return _balance; 
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            // ctrl r + ctrl m; extracted overdraft condition
            // to private bool (below) for readability
            if (NotOverdraft(amountToWithdraw)) 
            {
                _balance -= amountToWithdraw;
            }
            else
            {
                throw new AccountOverdraftException();
            }
        }

        // Never type "private"; Always refactor to it --"literate code"
        private bool NotOverdraft(decimal amountToWithdraw)
        {
            return amountToWithdraw <= _balance;
        }
    }
}
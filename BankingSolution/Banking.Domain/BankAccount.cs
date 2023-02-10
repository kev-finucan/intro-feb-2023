namespace Banking.Domain
{
    public class BankAccount
    {
        private decimal _balance = 5000M;
        private ICanCalculateAccountBonuses _bonusCalculator;

        // Constructors are for REQUIRED DEPENDENCIES when creating a class.
        public BankAccount(ICanCalculateAccountBonuses bonusCalculator)
        {
            _bonusCalculator = bonusCalculator;
        }

        public void Deposit(decimal amountToDeposit)
        {
            GuardNoNegativeAmountsForTransactions(amountToDeposit);
            // Write the code you wish you had.
            decimal bonus = _bonusCalculator.GetDepositBonusFor(_balance, amountToDeposit);
            _balance += amountToDeposit + bonus;
        }

        private static void GuardNoNegativeAmountsForTransactions(decimal amountToDeposit)
        {
            if (amountToDeposit < 0)
            {
                throw new NoNegativeNumbersException();
            }
        }

        public decimal GetBalance()
        {
            return _balance; 
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            GuardNoNegativeAmountsForTransactions(amountToWithdraw);
            // ctrl r + ctrl m; extracted overdraft condition
            // to private bool (below) for readability
            if (NotOverdraft(amountToWithdraw)) 
            {
                _balance -= amountToWithdraw;
                // Write the code you wish you had
                // _notifier.CheckForRequiredNotification(this, amountToWithdraw);
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
using Banking.Domain;

namespace BankingKiosk
{
    public partial class Form1 : Form
    {
        BankAccount _account;
        public Form1()
        {
            InitializeComponent();
            _account = new BankAccount(new StandardBonusCalculator(new StandardBusinessClock(new SystemTime())));
            UpdateBalanceDisplay();
        }

        private void DepositButton_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Deposit);
        }

        private void DoTransaction(Action<decimal> op)
        {
            try
            {
                var amount = decimal.Parse(amountInput.Text);
                op(amount);
                UpdateBalanceDisplay();
            }
            catch (FormatException) 
            {
                MessageBox.Show("Enter a number, you goofball!", "Error on Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (AccountOverdraftException) 
            {
                MessageBox.Show("You don't have enough money, goofball!", "Error on Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                amountInput.SelectAll();
                amountInput.Focus();
            }
        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Withdraw);
        }


        private void UpdateBalanceDisplay()
        {
            this.Text = $"You have a balance of {_account.GetBalance():c} Currently";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoTransaction((amount) => MessageBox.Show("You clicked a button " + amount.ToString()));
        }
    }
}
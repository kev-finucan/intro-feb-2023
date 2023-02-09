using Banking.Domain;
using static Banking.UnitTests.DummyBonusCalculator;

namespace Banking.UnitTests;

public class BankAccountDepositsUseTheBonusCalculator
{

    [Fact]
    public void BonusAppliedToDeposit()
    {
        var stubbedBonusCalculator = new Mock<ICanCalculateAccountBonuses>();
        var account = new BankAccount(new StubbedBonusCalculator());
        var openingBalance = account.GetBalance();
        var amountToDeposit = 118.32M;
        stubbedBonusCalculator.Setup(testCase =>
            testCase.GetDepositBonusFor(openingBalance, amountToDeposit)
        ).Returns(42.18M);

        account.Deposit(amountToDeposit);

        Assert.Equal(openingBalance + amountToDeposit + 42.18M, account.GetBalance());
    }
}
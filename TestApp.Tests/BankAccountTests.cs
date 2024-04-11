using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class BankAccountTests
{
    [Test]
    public void Test_Constructor_InitialBalanceIsSet()
    {
        // Arrange
        double inAmount = 100;

        // Act
        BankAccount account = new BankAccount(inAmount);

        // Assert
        Assert.That(account.Balance, Is.EqualTo(inAmount));

    }

    [Test]
    public void Test_Deposit_PositiveAmount_IncreasesBalance()
    {
        // Arrange
        double inAmount = 100;
        double moreAmount = 1500;

        double expectedAmount = 1600;

        // Act
        BankAccount account = new BankAccount(inAmount);
        account.Deposit(moreAmount);

        // Assert
        Assert.That(account.Balance, Is.EqualTo(expectedAmount));
    }

    [Test]
    public void Test_Deposit_NegativeAmount_ThrowsArgumentException()
    {
        // Arrange
        double inAmount = 100;
        double negativeAmount = -1500;

        // Act & Assert
        BankAccount account = new BankAccount(inAmount);
        Assert.That(()=> account.Deposit(negativeAmount), Throws.ArgumentException);
    }

    [Test]
    public void Test_Withdraw_ValidAmount_DecreasesBalance()
    {
        // Arrange
        double inAmount = 1500;
        double takedAmount = 400;

        double expectedAmount = 1100;

        // Act
        BankAccount account = new BankAccount(inAmount);
        account.Withdraw(takedAmount);

        // Assert
        Assert.That(account.Balance, Is.EqualTo(expectedAmount));
    }

    [Test]
    public void Test_Withdraw_NegativeAmount_ThrowsArgumentException()
    {
        // Arrange
        double inAmount = 1000;
        double negativeAmount = -500;

        // Act & Assert
        BankAccount account = new BankAccount(inAmount);
        Assert.That(() => account.Withdraw(negativeAmount), Throws.ArgumentException);
    }

    [Test]
    public void Test_Withdraw_AmountGreaterThanBalance_ThrowsArgumentException()
    {
        // Arrange
        double inAmount = 1300;
        double greaterAmount = 1500;

        // Act & Assert
        BankAccount account = new BankAccount(inAmount);
        Assert.That(() => account.Withdraw(greaterAmount), Throws.ArgumentException);
    }
}

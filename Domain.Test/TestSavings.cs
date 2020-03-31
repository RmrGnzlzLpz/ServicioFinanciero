using Domain.Entities;
using NUnit.Framework;
using System;

namespace Domain.Test
{
  public class Tests
  {
    SavingsAccount account;
    [SetUp]
    public void Setup()
    {
      account = new SavingsAccount
      {
        Balance = 0,
        City = "Valledupar",
        Name = "Cuenta Ejemplo",
        Number = "10001"
      };
    }

    [Test]
    public void Negative()
    {
      Transaction transaction = new Transaction
      {
        City = account.City,
        Amount = -10,
      };
      InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => account.Income(transaction));
      Assert.AreEqual(ex.Message, "El valor a consignar es incorrecto");
    }

    [Test]
    public void CorrectInitial()
    {
      Transaction transaction = new Transaction
      {
        Amount = 50000,
        City = account.City
      };
      account.Income(transaction);
      Assert.AreEqual(50000, account.Balance);
    }

    [Test]
    public void IncorrectInitial()
    {
      Transaction transaction = new Transaction
      {
        Amount = 49950,
        City = account.City
      };
      InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => account.Income(transaction));
      Assert.AreEqual(ex.Message, "El valor mínimo de la primera consignación debe ser de $50000 pesos. Su nuevo saldo es $0 pesos");
    }

    [Test]
    public void CorrectPosterior()
    {
      account.Balance = 30000;
      Transaction transaction = new Transaction
      {
        Amount = 49950,
        City = account.City
      };
      double expectedBalance = account.Balance + transaction.Amount;
      account.Income(transaction);
      
      Assert.AreEqual(account.Balance, expectedBalance);
    }
  }
}
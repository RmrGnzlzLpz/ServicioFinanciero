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

            Assert.AreEqual("El valor a consignar es incorrecto", account.Income(transaction));
        }

        [Test]
        public void CorrectInitial()
        {
            Transaction transaction = new Transaction
            {
                Amount = 50000,
                City = account.City
            };
            Assert.AreEqual("Su Nuevo Saldo es de $50000 pesos", account.Income(transaction));
        }

        [Test]
        public void IncorrectInitial()
        {
            Transaction transaction = new Transaction
            {
                Amount = 49950,
                City = account.City
            };
            Assert.AreEqual("El valor m�nimo de la primera consignaci�n debe ser de $50000 pesos. Su nuevo saldo es $0 pesos", account.Income(transaction));
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
            Assert.AreEqual("Su Nuevo Saldo es de $79950 pesos", account.Income(transaction));
        }
    }
}
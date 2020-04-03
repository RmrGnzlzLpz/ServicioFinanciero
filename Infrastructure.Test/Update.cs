using Domain.Entities;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Test
{
    class Update
    {
        FinancialService account;
        UnitOfWork unit;
        List<FinancialService> list = new List<FinancialService>();

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BancoContext>().UseSqlServer("Server=.\\;Database=Banco;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
            BancoContext context = new BancoContext(options);
            unit = new UnitOfWork(context);

            #region List
            list.Add(new SavingsAccount
            {
                Name = "Cuenta de Ahorro",
                City = "Valledupar",
                Number = "0001",
            });
            list.Add(new CheckingAccount
            {
                Name = "Cuenta Corriente",
                City = "Bogota",
                Number = "0002",
            });
            list.Add(new CreditCard
            {
                Name = "Tarjeta de Credito",
                City = "Barranquilla",
                Number = "0003",
            });
            list.Add(new Tdc
            {
                Name = "CDT",
                City = "Santa Marta",
                Number = "0004",
            });
            #endregion
        }

        [Test]
        public void UpdateFinancialService()
        {
            account = unit.FinancialServiceRepository.FindBy(f => f.Id == 11, includeProperties: "Transactions").FirstOrDefault();

            account.Income(new Transaction
            {
                Amount = 100000,
                City = "San Sebastian",
            });

            unit.FinancialServiceRepository.Edit(account); // Set State.Modified to account
            unit.Commit(); // Save changes in context

            Assert.AreEqual(account.Balance, unit.FinancialServiceRepository.FindBy(f => f.Name == "CDT").FirstOrDefault().Balance);
        }
    }
}

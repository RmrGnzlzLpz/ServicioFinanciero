using Domain.Entities;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace Infrastructure.Test
{
    public class Tests
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

            #region list
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
        public void CreateFinancialService()
        {
            account = new Tdc
            {
                Name = "Cuenta CDT",
                City = "Valledupar",
                Number = "0001",
                Balance = 0
            };
            unit.FinancialServiceRepository.Add(account);
            Assert.IsTrue(unit.Commit() > 0);
        }

        [Test]
        public void AddRangeFinancialService()
        {
            unit.FinancialServiceRepository.AddRange(list);
            int entities = unit.Commit();

            Assert.AreEqual(list.Count, entities);
        }
    }
}
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
    class Delete
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
        }

        [Test]
        public void DeleteFinancialService()
        {
            account = unit.FinancialServiceRepository.FindBy(f => f.Id == 11, includeProperties: "Transactions").FirstOrDefault();

            unit.FinancialServiceRepository.Delete(account);
            unit.Commit(); // Save changes in context

            Assert.IsNull(unit.FinancialServiceRepository.FindBy(f => f.Id == 11).FirstOrDefault());
        }
    }
}

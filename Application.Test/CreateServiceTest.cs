using Infrastructure;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections;
using Domain.Entities;
using Application.Models;
using Application.Services;
using Infrastructure.Base;

namespace Application.Test
{
    public class Tests
    {
        BancoContext _context;
        UnitOfWork unitOfWork;
        FinancialService account;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BancoContext>().UseSqlServer("Server=.\\;Database=Banco;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
            _context = new BancoContext(options);
            unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("Creations")]
        public void Create(CreateFinancialServiceRequest request, string expected)
        {
            CrearCuentaBancariaService service = new CrearCuentaBancariaService(unitOfWork);
            var response = service.Ejecutar(request);
            Assert.AreEqual(response.Message, expected);
        }

        private static IEnumerable Creations()
        {
            yield return new TestCaseData(
                new CreateFinancialServiceRequest
                {
                    AccountType = (int)Domain.Factory.FinancialServiceType.SavingsAccount,
                    City = "Valledupar",
                    Name = "Cuenta de prueba",
                    Number = "12321"
                },
                "Se creo con exito la cuenta 12321."
            ).SetName("CreateOk");
        }
    }
}
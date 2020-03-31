using Application;
using Infrastructure;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsInMemory = new DbContextOptionsBuilder<BancoContext>()
             .UseInMemoryDatabase("Banco")
             .Options;

            BancoContext context = new BancoContext(optionsInMemory);

            CrearCuentaBancaria(context);
            ConsignarCuentaBancaria(context);
        }

        private static void ConsignarCuentaBancaria(BancoContext context)
        {
            ConsignarService _service = new ConsignarService(new UnitOfWork(context));
            var request = new ConsignarRequest() { AccountNumber = "524255", Amount = 1000 };

            ConsignarResponse response = _service.Ejecutar(request);

            System.Console.WriteLine(response.Message);
            System.Console.ReadKey();
        }

        private static void CrearCuentaBancaria(BancoContext context)
        {

            CrearCuentaBancariaService _service = new CrearCuentaBancariaService(new UnitOfWork(context));
            var requestCrer = new CrearCuentaBancariaRequest() { Number = "524255", Name = "Boris Arturo" };

            CrearCuentaBancariaResponse responseCrear = _service.Ejecutar(requestCrer);

            System.Console.WriteLine(responseCrear.Message);
        }
    }
}

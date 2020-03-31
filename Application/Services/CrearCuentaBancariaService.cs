using Domain.Base;
using Domain.Entities;
using Domain.Contracts;
using Domain.Factory;
using Domain.Interfaces;

namespace Application.Services
{
  public class CrearCuentaBancariaService
  {
    readonly IUnitOfWork _unitOfWork;
    readonly IGenericFactory<FinancialService> _factory;

    public CrearCuentaBancariaService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
      _factory = new FinancialServiceFactory();
    }
    public CrearCuentaBancariaResponse Ejecutar(CrearCuentaBancariaRequest request)
    {
      FinancialService cuenta = _unitOfWork.FinancialServiceRepository.FindFirstOrDefault(t => t.Number == request.Number);
      if (cuenta != null) return new CrearCuentaBancariaResponse() { Message = "El número de cuenta ya existe." };

      try
      {
        FinancialService newAccount = _factory.CreateEntity(request.AccountType);
        newAccount.Name = request.Name;
        newAccount.Number = request.Number;

        _unitOfWork.FinancialServiceRepository.Add(newAccount);
        _unitOfWork.Commit();
        return new CrearCuentaBancariaResponse() { Message = $"Se creó con exito la cuenta {newAccount.Number} {newAccount.GetType()}." };
      }
      catch (System.Exception ex)
      {
        return new CrearCuentaBancariaResponse() { Message = ex.Message };
      }
    }
  }
  public class CrearCuentaBancariaRequest
  {
    public string Name { get; set; }
    public int AccountType { get; set; }
    public string Number { get; set; }
  }
  public class CrearCuentaBancariaResponse
  {
    public string Message { get; set; }
  }
}
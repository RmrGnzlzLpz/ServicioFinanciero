using Domain.Base;
using Domain.Entities;
using Domain.Contracts;
using Domain.Factory;
using Domain.Interfaces;
using Application.Models;

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
    public CreateFinancialServiceResponse Ejecutar(CreateFinancialServiceRequest request)
    {
      FinancialService cuenta = _unitOfWork.FinancialServiceRepository.FindFirstOrDefault(t => t.Number == request.Number);
      if (cuenta != null) return new CreateFinancialServiceResponse() { Message = "El número de cuenta ya existe." };

      try
      {
        FinancialService newAccount = _factory.CreateEntity(request.AccountType);
        newAccount.Name = request.Name;
        newAccount.Number = request.Number;
        newAccount.City = request.City;

        _unitOfWork.FinancialServiceRepository.Add(newAccount);
        _unitOfWork.Commit();
        return new CreateFinancialServiceResponse() { Message = $"Se creo con exito la cuenta {newAccount.Number}." };
      }
      catch (System.Exception ex)
      {
        return new CreateFinancialServiceResponse() { Message = ex.Message };
      }
    }
  }
}
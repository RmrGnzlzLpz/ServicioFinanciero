using Domain.Contracts;
using Domain.Entities;
using Domain.Repositories;
using System;

namespace Application.Services
{
  public class ConsignarService
  {
    readonly IUnitOfWork _unitOfWork;
    public ConsignarService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public ConsignarResponse Ejecutar(ConsignarRequest request)
    {
      var cuenta = _unitOfWork.FinancialServiceRepository.FindFirstOrDefault(t => t.Number == request.AccountNumber);
      if (cuenta == null) return new ConsignarResponse { Message = $"Error: Número de Cuenta {request.AccountNumber} No Válido." };
      try
      {
        cuenta.Income(new Transaction { Amount = request.Amount });
        _unitOfWork.Commit();
        return new ConsignarResponse() { Message = $"Su Nuevo saldo es {cuenta.Balance}." };
      }
      catch (InvalidOperationException ex)
      {
        return new ConsignarResponse() { Message = ex.Message };
      }
    }
  }

  public class ConsignarRequest
  {
    public string AccountNumber { get; set; }
    public double Amount { get; set; }
  }
  public class ConsignarResponse
  {
    public string Message { get; set; }
  }
}

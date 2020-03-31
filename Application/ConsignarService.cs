using Domain.Contracts;
using Domain.Entities;
using Domain.Repositories;

namespace Application
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
      if (cuenta != null)
      {
        cuenta.Income(new Transaction { Amount = request.Amount });
        _unitOfWork.Commit();
        return new ConsignarResponse() { Message = $"Su Nuevo saldo es {cuenta.Balance}." };
      }
      else
      {
        return new ConsignarResponse() { Message = $"Número de Cuenta No Válido." };
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

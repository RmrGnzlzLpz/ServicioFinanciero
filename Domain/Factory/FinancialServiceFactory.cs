using System;

using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Factory
{
  public class FinancialServiceFactory : IGenericFactory<FinancialService>
  {
    public FinancialService CreateEntity(int type)
    {
        FinancialServiceType accountType = (FinancialServiceType)type;
        switch (accountType)
        {
            case FinancialServiceType.CheckingAccount:
                return new CheckingAccount();
            case FinancialServiceType.CreditCard:
                return new CreditCard();
            case FinancialServiceType.SavingsAccount:
                return new SavingsAccount();
            case FinancialServiceType.Tdc:
                return new Tdc();
            default:
                throw new ArgumentOutOfRangeException(message: "Tipo de Cuenta No Válido.", innerException: null);
        }
    }
  }

  public enum FinancialServiceType
  {
      CheckingAccount = 0,
      CreditCard = 1,
      SavingsAccount = 2,
      Tdc = 3
  }
}
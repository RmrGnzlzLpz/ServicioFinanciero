using System;
using System.Linq;
using Domain.Base;

namespace Domain.Entities
{
    public class SavingsAccount : FinancialService
    {
        public SavingsAccount() : base(initialAmount: 50000, nationalCost: 10000, minimunBalance: 20000, additionalCost: 5000)
        {
        }
        override public string Income(Transaction transaction)
        {
            
            if (transaction.City != City) transaction.Amount -= _nationalCost;
            if (transaction.Amount <= 0)
            {
                return("El valor a consignar es incorrecto");
            }
            if (IsFirstTransaction && transaction.Amount < _initialAmount)
            {
                return($"El valor mínimo de la primera consignación debe ser de ${_initialAmount} pesos. Su nuevo saldo es ${Balance} pesos");
            }
            return base.Income(transaction);
        }

        override public string Discharge(Transaction transaccion)
        {
            if ((Balance - transaccion.Amount) < _minimunBalance)
            {
                return($"El saldo mínimo de la cuenta deberá ser de ${_minimunBalance} pesos");
            }
            if (Transactions.Where(t => t.DateTime.Month == DateTime.UtcNow.Month).ToList().Count > 3)
            {
                transaccion.Amount += _additionalCost;
            }
            return base.Discharge(transaccion);
        }
    }
}

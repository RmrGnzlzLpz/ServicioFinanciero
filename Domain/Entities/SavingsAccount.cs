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
        override public void Income(Transaction transaction)
        {
            if (transaction.City != City) transaction.Amount -= _nationalCost;
            if (transaction.Amount <= 0)
            {
                throw new InvalidOperationException("El valor a consignar es incorrecto");
            }
            if (IsFirstTransaction && transaction.Amount < _initialAmount)
            {
                throw new InvalidOperationException($"El valor mínimo de la primera consignación debe ser de ${_initialAmount} pesos. Su nuevo saldo es ${Balance} pesos");
            }
            base.Income(transaction);
        }

        override public void Discharge(Transaction transaccion)
        {
            if ((Balance - transaccion.Amount) < _minimunBalance)
            {
                throw new InvalidOperationException($"El saldo mínimo de la cuenta deberá ser de ${_minimunBalance} pesos");
            }
            if (Transactions.Where(t => t.DateTime.Month == DateTime.UtcNow.Month).ToList().Count > 3)
            {
                transaccion.Amount += _additionalCost;
            }
            base.Discharge(transaccion);
        }
    }
}

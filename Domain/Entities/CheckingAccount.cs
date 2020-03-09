using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;

namespace Domain.Entities
{
    public class CheckingAccount : FinancialService
    {
        private readonly double _overdraftQuota;
        public CheckingAccount(double overdraftQuota = 0) : base(initialAmount: 10000)
        {
        }

        override public string Income(ValueObject.Transaction transaction)
        {
            if (IsFirstTransaction && transaction.Amount < _initialAmount)
            {
                return($"La consignación mínima de ${_initialAmount} pesos");
            }
            return base.Income(transaction);
        }

        override public string Discharge(ValueObject.Transaction transaction)
        {
            transaction.Amount += 4 * (transaction.Amount % 1000);
            if ((Balance - transaction.Amount) < (-1 * _overdraftQuota))
            {
                return($"El saldo mínimo debe ser mayor o igual al cupo de sobregiro (${_overdraftQuota} pesos)");
            }
            return base.Discharge(transaction);
        }
    }
}

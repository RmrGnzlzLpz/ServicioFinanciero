using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;

namespace Domain.Entities
{
    public class CheckingAccount : FinancialService
    {
        private readonly double _overdraftQuota;
        public CheckingAccount() : base(initialAmount: 10000)
        {
            _overdraftQuota = 50000;
        }

        public override void Income(Transaction transaction)
        {
            if (IsFirstTransaction && transaction.Amount < _initialAmount)
            {
                throw new InvalidOperationException($"La consignación mínima de ${_initialAmount} pesos");
            }
            base.Income(transaction);
        }

        public override void Discharge(Transaction transaction)
        {
            transaction.Amount += 4 * (transaction.Amount % 1000);
            // 0 - 49.000 < - 50.000
            if ((Balance - transaction.Amount) < (-1 * _overdraftQuota))
            {
                throw new InvalidOperationException($"El saldo mínimo debe ser mayor o igual al cupo de sobregiro (${_overdraftQuota} pesos)");
            }
            base.Discharge(transaction);
        }
    }
}

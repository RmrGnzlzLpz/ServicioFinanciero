using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;

namespace Domain.Entities
{
    public class CreditCard : FinancialService
    {
        private readonly double _preApprovedQuota;

        public CreditCard()
        {
            
        }
        public CreditCard(double preApprovedQuota = 0)
        {
            _preApprovedQuota = preApprovedQuota;
        }

        override
        public void Income(Transaction transaction)
        {
            if (transaction.Amount <= 0)
            {
                throw new InvalidOperationException("El valor de abono no puede ser menor o igual a 0");
            }
            if (transaction.Amount > (-1 * Balance))
            {
                throw new InvalidOperationException("El valor de abono no puede ser mayor al saldo de la tarjeta");
            }
            base.Income(transaction);
        }
        override
        public void Discharge(Transaction transaction)
        {
            if (transaction.Amount <= 0)
            {
                throw new InvalidOperationException("El valor del avance debe ser mayor a 0");
            }
            if (transaction.Amount > (-1 * Balance))
            {
                throw new InvalidOperationException("El valor del avance no puede ser mayor al valor disponible de la tarjeta");
            }
            base.Discharge(transaction);
        }
    }
}

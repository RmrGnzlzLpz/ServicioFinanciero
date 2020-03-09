using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;
using Domain.ValueObject;

namespace Domain.Entities
{
    public class CreditCard : FinancialService
    {
        private readonly double _preApprovedQuota;

        public CreditCard(double preApprovedQuota = 0)
        {
            _preApprovedQuota = preApprovedQuota;
        }

        override
        public string Income(Transaction transaction)
        {
            if (transaction.Amount <= 0)
            {
                return("El valor de abono no puede ser menor o igual a 0");
            }
            if (transaction.Amount > (-1 * Balance))
            {
                return("El valor de abono no puede ser mayor al saldo de la tarjeta");
            }
            return base.Income(transaction);
        }
        override
        public string Discharge(Transaction transaction)
        {
            if (transaction.Amount <= 0)
            {
                return("El valor del avance debe ser mayor a 0");
            }
            if (transaction.Amount > (-1 * Balance))
            {
                return("El valor del avance no puede ser mayor al valor disponible de la tarjeta");
            }
            return base.Discharge(transaction);
        }
    }
}

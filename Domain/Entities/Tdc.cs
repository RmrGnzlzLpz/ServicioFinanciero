using System;
using Domain.Base;
using Domain.ValueObject;
using System.Linq;

namespace Domain.Entities
{
    public class Tdc : FinancialService
    {
        private readonly double _annualInterestRate = 6;
        private readonly int _days;

        public Tdc(int annualInterestRate = 0, int days = 365) : base(initialAmount: 1000000)
        {
            _annualInterestRate = annualInterestRate;
            _days = days;
        }
        override
        public string Income(Transaction transaction)
        {
            if (!IsFirstTransaction)
            {
                return("Solo se puede realizar una consignación");
            }
            if (IsFirstTransaction && transaction.Amount < _initialAmount)
            {
                return($"El valor de consignación inicial debe ser de mínimo ${_initialAmount} de pesos");
            }
            return base.Income(transaction);
        }
        override
        public string Discharge(Transaction transaction)
        {
            DateTime date = Transactions.Where(t => t.Type == TransactionType.Income).FirstOrDefault().DateTime;
            date.AddDays(_days);
            if (date > DateTime.UtcNow)
            {
                return("El término del CDT aún no ha finalizado");
            }
            Balance += transaction.Amount * _annualInterestRate / 100;
            return base.Discharge(transaction);
        }
    }
}

using System;
using Domain.Base;
using System.Linq;

namespace Domain.Entities
{
    public class Tdc : FinancialService
    {
        private readonly double _annualInterestRate = 6;
        private readonly int _days = 365;

        public Tdc()
        {
        }
        public Tdc(int annualInterestRate = 0, int days = 365) : base(initialAmount: 1000000)
        {
            _annualInterestRate = annualInterestRate;
            _days = days;
        }
        override
        public void Income(Transaction transaction)
        {
            if (!IsFirstTransaction)
            {
                throw new InvalidOperationException("Solo se puede realizar una consignación");
            }
            if (transaction.Amount < _initialAmount)
            {
                throw new InvalidOperationException($"El valor de consignación inicial debe ser de mínimo ${_initialAmount} de pesos");
            }
            base.Income(transaction);
        }
        override
        public void Discharge(Transaction transaction)
        {
            DateTime date = Transactions.Where(t => t.Type == TransactionType.Income).FirstOrDefault().DateTime;
            date.AddDays(_days);
            if (date > DateTime.UtcNow)
            {
                throw new InvalidOperationException("El término del CDT aún no ha finalizado");
            }
            Balance += transaction.Amount * _annualInterestRate / 100;
            base.Discharge(transaction);
        }
    }
}

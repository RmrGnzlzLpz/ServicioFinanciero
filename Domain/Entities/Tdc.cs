using System;
using Domain.Base;
using System.Linq;

namespace Domain.Entities
{
    public class Tdc : FinancialService
    {
        public double AnnualInterestRate { get; set; } = 6;
        public int Days { get; set; } = 365;

        public Tdc()
        {
        }

        public Tdc(int annualInterestRate = 0, int days = 365) : base(initialAmount: 1000000)
        {
            AnnualInterestRate = annualInterestRate;
            Days = days;
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
            date.AddDays(Days);
            if (date > DateTime.UtcNow)
            {
                throw new InvalidOperationException("El término del CDT aún no ha finalizado");
            }
            Balance += transaction.Amount * AnnualInterestRate / 100;
            base.Discharge(transaction);
        }
    }
}

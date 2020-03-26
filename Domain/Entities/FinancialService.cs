using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Entities
{
    public abstract class FinancialService : Entity<int>, IFinancialService
    {
        protected double _initialAmount;
        protected double _nationalCost;
        protected double _minimunBalance;
        protected double _additionalCost;
        public string Number { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public double Balance { get; set; }
        public IList<Transaction> Transactions { get; set; }
        protected bool IsFirstTransaction { get => Balance == 0; }

        public FinancialService(double initialAmount = 0, double nationalCost = 0, double minimunBalance = 0, double additionalCost = 0)
        {
            Transactions = new List<Transaction>();
            _initialAmount = initialAmount;
            _nationalCost = nationalCost;
            _minimunBalance = minimunBalance;
            _additionalCost = additionalCost;
        }

        public virtual string Income(Transaction transaction)
        {
            transaction.Type = TransactionType.Income;
            Transactions.Add(transaction);
            Balance += transaction.Amount;
            return $"Su Nuevo Saldo es de ${Balance} pesos";
        }

        public virtual string Discharge(Transaction transaction)
        {
            transaction.Type = TransactionType.Discharge;
            Transactions.Add(transaction);
            Balance -= transaction.Amount;
            return $"Su Nuevo Saldo es de ${Balance} pesos";
        }

        public virtual string Translate(Transaction transaction, IFinancialService account)
        {
            Discharge(transaction);
            account.Income(transaction);
            return $"Transacción exitosa por valor de {transaction.Amount}";
        }

        override
        public string ToString()
        {
            return $"Number:{Number}, Name:{Name}, City:{City}, Balance: {Balance}, Transactions:{Transactions.Count}";
        }
    }
}

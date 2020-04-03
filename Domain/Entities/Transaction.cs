using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;

namespace Domain.Entities
{
    public class Transaction : Entity<int>
    {
        public double Amount { get; set; }
        public string City { get; set; }
        public DateTime DateTime { get; set; } =  DateTime.UtcNow;
        public TransactionType Type { get; set; }
    }

    public enum TransactionType
    {
        Discharge = 0,
        Income = 1,
    }
}

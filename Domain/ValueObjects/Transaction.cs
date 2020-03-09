using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObject
{
    public class Transaction
    {
        public double Amount { get; set; }
        public string City { get; set; }
        public DateTime DateTime {get; set;} =  DateTime.Now;
        public TransactionType Type { get; set; }
    }

    public enum TransactionType
    {
        Discharge = 0,
        Income = 1,
    }
}

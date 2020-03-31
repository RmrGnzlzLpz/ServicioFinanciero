using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IFinancialService
    {
        string Number { get; set; }
        string Name { get; set; }
        double Balance { get; set; }
        void Income(Transaction transaccion);
        void Discharge(Transaction transaccion);
        void Translate(Transaction transaction, IFinancialService account);
    }
}

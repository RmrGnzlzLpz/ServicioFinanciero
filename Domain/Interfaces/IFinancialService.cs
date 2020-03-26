using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IFinancialService
    {
        string Income(Transaction transaccion);
        string Discharge(Transaction transaccion);
        string Translate(Transaction transaction, IFinancialService account);
    }
}

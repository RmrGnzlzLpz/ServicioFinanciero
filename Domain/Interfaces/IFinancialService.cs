using System;
using System.Collections.Generic;
using System.Text;
using Domain.ValueObject;

namespace Domain.Interfaces
{
    interface IFinancialService
    {
        string Income(Transaction transaccion);
        string Discharge(Transaction transaccion);
    }
}

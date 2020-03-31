using System;
using Domain.Repositories;

namespace Domain.Contracts
{
  public interface IUnitOfWork : IDisposable
  {
    IFinancialServiceRepository FinancialServiceRepository { get; }
    int Commit();
  }
}
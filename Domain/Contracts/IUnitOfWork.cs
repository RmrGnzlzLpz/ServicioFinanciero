using System;
using Domain.Repositories;

namespace Domain.Contracts
{
  public interface IUnitOfWork : IDisposable
  {
    ICuentaBancariaRepository CuentaBancariaRepository { get; }
    int Commit();
  }
}
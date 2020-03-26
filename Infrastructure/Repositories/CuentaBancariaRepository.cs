using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
  public class CuentaBancariaRepository : GenericRepository<FinancialService>, ICuentaBancariaRepository
  {
    public CuentaBancariaRepository(IDbContext context) : base(context)
    {
    }
  }
}
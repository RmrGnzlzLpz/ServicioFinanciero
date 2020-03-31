using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
  public class FinancialServiceRepository : GenericRepository<FinancialService>, IFinancialServiceRepository
  {
    public FinancialServiceRepository(IDbContext context) : base(context)
    {
    }
  }
}
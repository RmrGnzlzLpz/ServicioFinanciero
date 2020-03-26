using Domain.Entities;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
  public class BancoContext : DbContextBase
  {
    public BancoContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<SavingsAccount> SavingsAccounts { get; set; }
    public DbSet<CheckingAccount> CheckingAccounts { get; set; }
  }
}

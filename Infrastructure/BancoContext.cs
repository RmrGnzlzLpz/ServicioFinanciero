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

        // Esta línea fue necesaria debido a que me decía que la clase FinancialService (clase abstracta) no había sido agregada en el modelo
        public DbSet<FinancialService> FinancialServices { get; set; }
        public DbSet<SavingsAccount> SavingsAccounts { get; set; }
        public DbSet<CheckingAccount> CheckingAccounts { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Tdc> Tdcs { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          // modelBuilder.Entity<SavingsAccount>().ToTable("SavingsAccounts");
          // modelBuilder.Entity<CheckingAccount>().ToTable("CheckingAccounts");
          // modelBuilder.Entity<CreditCard>().ToTable("CreditCards");
          // modelBuilder.Entity<Tdc>().ToTable("Tdcs");
          modelBuilder.Entity<Transaction>().ToTable("transactions");
          modelBuilder.Entity<FinancialService>().ToTable("financial_services");
        }
  }
}

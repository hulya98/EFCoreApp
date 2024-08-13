using EFCoreApp.Domain.Entities;
using EFCoreApp.Domain.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.Domain
{
    public class Context : DbContext
    {
        public Context()
        {
            
        }
        public Context(DbContextOptions<Context> options)
        : base(options)
        {
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessUnitConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var migrationsConnectionString = @"Server=localhost;Database=ERP;User Id=sa;Password=Salamsalam1!;TrustServerCertificate=True;"
;

            optionsBuilder.UseSqlServer(migrationsConnectionString);

        }
    }
}

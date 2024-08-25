using EFCoreApp.Domain.EntityTypeConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreApp.Domain.Entities;

namespace EFCoreApp.Domain
{
    public sealed class Context : IdentityDbContext<AppUser, AppRole, Guid, IdentityUserClaim<Guid>, AppUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>

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
        public DbSet<BusinessUnitCurrency> BusinessUnitCurrencies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessUnitConfiguration());

            modelBuilder.Entity<BusinessUnitCurrency>()
                .ToView("VW_BusinessUnitCurrency")
                .HasNoKey();


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var migrationsConnectionString = @"Server=localhost;Database=ERP;Trusted_connection=true;TrustServerCertificate=True;";
            //var migrationsConnectionString = @"Server=localhost;Database=ERP;User Id=sa;Password=Salamsalam1!;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(migrationsConnectionString);

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.ModifiedDate = DateTime.UtcNow,
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

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
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EFCoreApp.Domain
{
    public sealed class Context : IdentityDbContext<AppUser, AppRole, Guid, IdentityUserClaim<Guid>, AppUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options, IHttpContextAccessor httpContextAccessor)
        : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public DbSet<Currency> Currencies { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<BusinessUnitCurrency> BusinessUnitCurrencies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessUnitConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserRoleConfiguration());

            modelBuilder.Ignore<IdentityUserLogin<Guid>>();
            modelBuilder.Ignore<IdentityUserToken<Guid>>();
            modelBuilder.Ignore<IdentityUserClaim<Guid>>();
            modelBuilder.Ignore<IdentityRoleClaim<Guid>>();

            modelBuilder.Entity<BusinessUnitCurrency>()
                .ToView("VW_BusinessUnitCurrency")
                .HasNoKey();


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var migrationsConnectionString = @"Server=localhost;Database=ERP;Trusted_connection=true;TrustServerCertificate=True;"; 
            var migrationsConnectionString = @"Server=88.198.193.132;Database=EFCoreApp;User Id=SLUser;Password=Sluser2020;TrustServerCertificate=True;";
            //var migrationsConnectionString = @"Server=localhost;Database=ERP;User Id=sa;Password=Salamsalam1!;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(migrationsConnectionString);

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.UtcNow;
                        data.Entity.CreatedBy = userId;
                        break;
                    case EntityState.Modified:
                        data.Entity.ModifiedDate = DateTime.UtcNow;
                        data.Entity.ModifiedBy = userId;
                        break;
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

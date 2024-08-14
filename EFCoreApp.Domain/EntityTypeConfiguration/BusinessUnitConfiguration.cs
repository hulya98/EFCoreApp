using EFCoreApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.Domain.EntityTypeConfiguration
{
    public class BusinessUnitConfiguration : IEntityTypeConfiguration<BusinessUnit>
    {
        public void Configure(EntityTypeBuilder<BusinessUnit> builder)
        {
            builder.HasOne(b => b.BaseCurrency)
              .WithMany(c => c.BaseBusinessUnits)
              .HasForeignKey(b => b.BaseCurrencyId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.ReportCurrency)
                   .WithMany(c => c.ReportBusinessUnits)
                   .HasForeignKey(b => b.ReportCurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.BusinessUnitCode).IsUnique();

            builder.Property(x => x.BusinessUnitCode).HasMaxLength(3);
            builder.Property(x => x.BusinessUnitName).HasMaxLength(200);

            builder.HasData(new BusinessUnit
            {
                BusinessUnitId = 1,
                BusinessUnitCode = "ADY",
                BusinessUnitName = "Azərbaycan Dəmir yolları",
                BaseCurrencyId = 1,
                ReportCurrencyId = 1
            });
        }
    }
}

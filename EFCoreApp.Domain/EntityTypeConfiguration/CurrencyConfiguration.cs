using EFCoreApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.Domain.EntityTypeConfiguration
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasData(new Currency
            {
                CurrencyId = 1,
                CurrencyKey = "AZN",
                CurrencyName = "Azərbaycan manatı"
            });

        }
    }
}

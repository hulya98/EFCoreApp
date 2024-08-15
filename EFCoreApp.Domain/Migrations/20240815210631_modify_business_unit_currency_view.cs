using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreApp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class modify_business_unit_currency_view : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"ALTER VIEW VW_BusinessUnitCurrency " +
                                "AS select " +
                                "BusinessUnitId,BusinessUnitCode,BusinessUnitName," +
                                "BaseCurrencyId,ReportCurrencyId," +
                                "c1.CurrencyKey BaseCurrencyName,c2.CurrencyKey ReportCurrencyName, " +
                                "b.CreatedDate,b.ModifiedDate from dbo.BusinessUnits b " +
                                "LEFT JOIN dbo.Currencies c1 ON BaseCurrencyId = c1.CurrencyId " +
                                "LEFT JOIN dbo.Currencies c2 ON ReportCurrencyId = c2.CurrencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"Drop Procedure SP_BusinessUnitCurrency");
        }
    }
}

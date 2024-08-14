using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreApp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class unique_constraint_configured_for_business_unit_and_currency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CurrencyKey",
                table: "Currencies",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BusinessUnitCode",
                table: "BusinessUnits",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_CurrencyKey",
                table: "Currencies",
                column: "CurrencyKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnits_BusinessUnitCode",
                table: "BusinessUnits",
                column: "BusinessUnitCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Currencies_CurrencyKey",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_BusinessUnits_BusinessUnitCode",
                table: "BusinessUnits");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyKey",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "BusinessUnitCode",
                table: "BusinessUnits",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

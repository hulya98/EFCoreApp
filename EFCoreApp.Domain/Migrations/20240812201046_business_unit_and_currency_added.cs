using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreApp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class business_unit_and_currency_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnits",
                columns: table => new
                {
                    BusinessUnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessUnitCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessUnitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseCurrencyId = table.Column<int>(type: "int", nullable: false),
                    ReportCurrencyId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnits", x => x.BusinessUnitId);
                    table.ForeignKey(
                        name: "FK_BusinessUnits_Currencies_BaseCurrencyId",
                        column: x => x.BaseCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessUnits_Currencies_ReportCurrencyId",
                        column: x => x.ReportCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencyId", "CreatedBy", "CreatedDate", "CurrencyKey", "CurrencyName", "ModifiedBy", "ModifiedDate" },
                values: new object[] { 1, null, null, "AZN", "Azərbaycan manatı", null, null });

            migrationBuilder.InsertData(
                table: "BusinessUnits",
                columns: new[] { "BusinessUnitId", "BaseCurrencyId", "BusinessUnitCode", "BusinessUnitName", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "ReportCurrencyId" },
                values: new object[] { 1, 1, "ADY", "Azərbaycan Dəmir yolları", null, null, null, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnits_BaseCurrencyId",
                table: "BusinessUnits",
                column: "BaseCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnits_ReportCurrencyId",
                table: "BusinessUnits",
                column: "ReportCurrencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessUnits");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}

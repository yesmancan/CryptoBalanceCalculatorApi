using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoApp.Data.Migrations
{
    public partial class Update_CurrencyTable_11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Unit",
                schema: "Application",
                table: "Transactions",
                type: "decimal(27,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(27,18)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Unit",
                schema: "Application",
                table: "Transactions",
                type: "decimal(27,18)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(27,8)");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoApp.Data.Migrations
{
    public partial class Update_CurrencyTable_9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Unit",
                schema: "Application",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Unit",
                schema: "Application",
                table: "Transactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}

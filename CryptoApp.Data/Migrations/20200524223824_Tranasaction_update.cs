using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoApp.Data.Migrations
{
    public partial class Tranasaction_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "Application",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<decimal>(
                name: "BuyingPrice",
                schema: "Application",
                table: "Transactions",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsSold",
                schema: "Application",
                table: "Transactions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "SellPrice",
                schema: "Application",
                table: "Transactions",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "Application",
                table: "Companies",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyingPrice",
                schema: "Application",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "IsSold",
                schema: "Application",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SellPrice",
                schema: "Application",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "Application",
                table: "Transactions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "Application",
                table: "Companies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}

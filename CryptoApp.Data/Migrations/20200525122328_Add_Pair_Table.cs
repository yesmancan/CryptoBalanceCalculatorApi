using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoApp.Data.Migrations
{
    public partial class Add_Pair_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SellPrice",
                schema: "Application",
                table: "Transactions",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "Application",
                table: "Transactions",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BuyingPrice",
                schema: "Application",
                table: "Transactions",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "Application",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Pairs",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreateDt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdateDt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Normalized = table.Column<string>(type: "nvarchar(25)", maxLength: 250, nullable: false),
                    Denominator = table.Column<string>(type: "nvarchar(25)", maxLength: 250, nullable: false),
                    Numerator = table.Column<string>(type: "nvarchar(25)", maxLength: 250, nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pairs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pairs",
                schema: "Application");

            migrationBuilder.AlterColumn<decimal>(
                name: "SellPrice",
                schema: "Application",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "Application",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BuyingPrice",
                schema: "Application",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "Application",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

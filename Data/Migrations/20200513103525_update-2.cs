using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoBalanceCalculatorApi.Data.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "CryptoHistoryItem");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CryptoHistoryItem",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDt",
                table: "CryptoHistoryItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CryptoHistoryItem",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreateDt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    UpdateDt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    LongName = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreateDt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    UpdateDt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CryptoHistoryItem");

            migrationBuilder.DropColumn(
                name: "UpdateDt",
                table: "CryptoHistoryItem");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CryptoHistoryItem");

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "CryptoHistoryItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

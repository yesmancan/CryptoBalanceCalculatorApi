using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoBalanceCalculatorApi.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptoHistoryItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CoinName = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    PaymentType = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    CreateDt = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoHistoryItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    Secret = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    CryptoHistoryItemId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rate_CryptoHistoryItem_CryptoHistoryItemId",
                        column: x => x.CryptoHistoryItemId,
                        principalTable: "CryptoHistoryItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rate_CryptoHistoryItemId",
                table: "Rate",
                column: "CryptoHistoryItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DropTable(
                name: "TodoItem");

            migrationBuilder.DropTable(
                name: "CryptoHistoryItem");
        }
    }
}

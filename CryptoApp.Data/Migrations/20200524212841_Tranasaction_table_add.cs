using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoApp.Data.Migrations
{
    public partial class Tranasaction_table_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreateDt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    UpdateDt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Market = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Coin = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Unit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions",
                schema: "Application");
        }
    }
}

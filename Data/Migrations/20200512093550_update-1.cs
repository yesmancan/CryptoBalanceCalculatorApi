using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoBalanceCalculatorApi.Data.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.AddColumn<string>(
                name: "Rates",
                table: "CryptoHistoryItem",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rates",
                table: "CryptoHistoryItem");

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CryptoHistoryItemId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}

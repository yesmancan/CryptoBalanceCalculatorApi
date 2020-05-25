using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoApp.Data.Migrations
{
    public partial class currency_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pair",
                schema: "Application",
                table: "Currency",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PairNormalized",
                schema: "Application",
                table: "Currency",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pair",
                schema: "Application",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "PairNormalized",
                schema: "Application",
                table: "Currency");
        }
    }
}

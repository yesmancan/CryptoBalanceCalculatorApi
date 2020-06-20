using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoApp.Data.Migrations
{
    public partial class UpdateDecimalValue1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Volume",
                schema: "Application",
                table: "Currency",
                type: "decimal(16,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Open",
                schema: "Application",
                table: "Currency",
                type: "decimal(16,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Low",
                schema: "Application",
                table: "Currency",
                type: "decimal(16,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Last",
                schema: "Application",
                table: "Currency",
                type: "decimal(16,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "High",
                schema: "Application",
                table: "Currency",
                type: "decimal(16,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DailyPercent",
                schema: "Application",
                table: "Currency",
                type: "decimal(16,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Daily",
                schema: "Application",
                table: "Currency",
                type: "decimal(16,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Bid",
                schema: "Application",
                table: "Currency",
                type: "decimal(16,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Average",
                schema: "Application",
                table: "Currency",
                type: "decimal(16,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Ask",
                schema: "Application",
                table: "Currency",
                type: "decimal(16,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Volume",
                schema: "Application",
                table: "Currency",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Open",
                schema: "Application",
                table: "Currency",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Low",
                schema: "Application",
                table: "Currency",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Last",
                schema: "Application",
                table: "Currency",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "High",
                schema: "Application",
                table: "Currency",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DailyPercent",
                schema: "Application",
                table: "Currency",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Daily",
                schema: "Application",
                table: "Currency",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Bid",
                schema: "Application",
                table: "Currency",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Average",
                schema: "Application",
                table: "Currency",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Ask",
                schema: "Application",
                table: "Currency",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,8)");
        }
    }
}

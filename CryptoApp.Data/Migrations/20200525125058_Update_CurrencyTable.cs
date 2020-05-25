using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoApp.Data.Migrations
{
    public partial class Update_CurrencyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DenominatorSymbol",
                schema: "Application",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "LongName",
                schema: "Application",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Application",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "NumeratorSymbol",
                schema: "Application",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "Pair",
                schema: "Application",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "PairNormalized",
                schema: "Application",
                table: "Currency");

            migrationBuilder.AddColumn<Guid>(
                name: "PairId",
                schema: "Application",
                table: "Currency",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PairId",
                schema: "Application",
                table: "Currency");

            migrationBuilder.AddColumn<string>(
                name: "DenominatorSymbol",
                schema: "Application",
                table: "Currency",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LongName",
                schema: "Application",
                table: "Currency",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Application",
                table: "Currency",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeratorSymbol",
                schema: "Application",
                table: "Currency",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pair",
                schema: "Application",
                table: "Currency",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PairNormalized",
                schema: "Application",
                table: "Currency",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoApp.Data.Migrations
{
    public partial class Update_CurrencyTable_14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currency_Companies_CompaniesId",
                schema: "Application",
                table: "Currency");

            migrationBuilder.DropForeignKey(
                name: "FK_Currency_Pairs_PairsId",
                schema: "Application",
                table: "Currency");

            migrationBuilder.DropIndex(
                name: "IX_Currency_CompaniesId",
                schema: "Application",
                table: "Currency");

            migrationBuilder.DropIndex(
                name: "IX_Currency_PairsId",
                schema: "Application",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "CompaniesId",
                schema: "Application",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "PairsId",
                schema: "Application",
                table: "Currency");

            migrationBuilder.AddColumn<Guid>(
                name: "Companies",
                schema: "Application",
                table: "Currency",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Pairs",
                schema: "Application",
                table: "Currency",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Companies",
                schema: "Application",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "Pairs",
                schema: "Application",
                table: "Currency");

            migrationBuilder.AddColumn<Guid>(
                name: "CompaniesId",
                schema: "Application",
                table: "Currency",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PairsId",
                schema: "Application",
                table: "Currency",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currency_CompaniesId",
                schema: "Application",
                table: "Currency",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_PairsId",
                schema: "Application",
                table: "Currency",
                column: "PairsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Currency_Companies_CompaniesId",
                schema: "Application",
                table: "Currency",
                column: "CompaniesId",
                principalSchema: "Application",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Currency_Pairs_PairsId",
                schema: "Application",
                table: "Currency",
                column: "PairsId",
                principalSchema: "Application",
                principalTable: "Pairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

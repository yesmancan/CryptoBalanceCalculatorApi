using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoApp.Data.Migrations
{
    public partial class Update_CurrencyTable_8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currency_Pairs_PairId",
                schema: "Application",
                table: "Currency");

            migrationBuilder.DropIndex(
                name: "IX_Currency_PairId",
                schema: "Application",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "PairId",
                schema: "Application",
                table: "Currency");

            migrationBuilder.AddColumn<Guid>(
                name: "PairsId",
                schema: "Application",
                table: "Currency",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currency_PairsId",
                schema: "Application",
                table: "Currency",
                column: "PairsId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currency_Pairs_PairsId",
                schema: "Application",
                table: "Currency");

            migrationBuilder.DropIndex(
                name: "IX_Currency_PairsId",
                schema: "Application",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "PairsId",
                schema: "Application",
                table: "Currency");

            migrationBuilder.AddColumn<Guid>(
                name: "PairId",
                schema: "Application",
                table: "Currency",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currency_PairId",
                schema: "Application",
                table: "Currency",
                column: "PairId");

            migrationBuilder.AddForeignKey(
                name: "FK_Currency_Pairs_PairId",
                schema: "Application",
                table: "Currency",
                column: "PairId",
                principalSchema: "Application",
                principalTable: "Pairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

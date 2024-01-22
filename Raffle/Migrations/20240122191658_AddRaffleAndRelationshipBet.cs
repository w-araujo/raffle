using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Raffle.Migrations
{
    /// <inheritdoc />
    public partial class AddRaffleAndRelationshipBet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Raffle1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    prizeValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    dataRaffle = table.Column<DateTime>(type: "TEXT", nullable: false),
                    result = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raffle1", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bet_RaffleId",
                table: "Bet",
                column: "RaffleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_Raffle1_RaffleId",
                table: "Bet",
                column: "RaffleId",
                principalTable: "Raffle1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bet_Raffle1_RaffleId",
                table: "Bet");

            migrationBuilder.DropTable(
                name: "Raffle1");

            migrationBuilder.DropIndex(
                name: "IX_Bet_RaffleId",
                table: "Bet");
        }
    }
}

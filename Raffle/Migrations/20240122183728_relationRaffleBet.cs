using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Raffle.Migrations
{
    /// <inheritdoc />
    public partial class relationRaffleBet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RaffleId",
                table: "Bet",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RaffleId",
                table: "Bet");
        }
    }
}

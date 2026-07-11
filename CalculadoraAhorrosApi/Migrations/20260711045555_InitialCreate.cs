using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculadoraAhorrosApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "simulations",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    initial_amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    initial_tax_yearly = table.Column<decimal>(type: "TEXT", nullable: false),
                    PlazoDeAños = table.Column<int>(type: "INTEGER", nullable: false),
                    FinalAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalInterest = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_simulations", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "simulations");
        }
    }
}

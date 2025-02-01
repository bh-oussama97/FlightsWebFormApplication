using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webforms.Migrations
{
    public partial class FlightsSchemaWithData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Timeplaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Place = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timeplaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Airline = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    DepartureId = table.Column<int>(nullable: false),
                    ArrivalId = table.Column<int>(nullable: false),
                    RemainingNumberOfSeats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Timeplaces_ArrivalId",
                        column: x => x.ArrivalId,
                        principalTable: "Timeplaces",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flights_Timeplaces_DepartureId",
                        column: x => x.DepartureId,
                        principalTable: "Timeplaces",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Timeplaces",
                columns: new[] { "Id", "Place", "Time" },
                values: new object[,]
                {
                    { 1, "Los Angeles", new DateTime(2025, 2, 1, 14, 52, 46, 383, DateTimeKind.Local).AddTicks(3017) },
                    { 2, "Istanbul", new DateTime(2025, 2, 1, 21, 52, 46, 384, DateTimeKind.Local).AddTicks(3004) },
                    { 3, "Munchen", new DateTime(2025, 2, 1, 17, 52, 46, 384, DateTimeKind.Local).AddTicks(3004) },
                    { 4, "Schiphol", new DateTime(2025, 2, 1, 19, 52, 46, 384, DateTimeKind.Local).AddTicks(3004) },
                    { 5, "London, England", new DateTime(2025, 2, 1, 23, 52, 46, 384, DateTimeKind.Local).AddTicks(3004) },
                    { 6, "Vizzola-Ticino", new DateTime(2025, 2, 2, 3, 52, 46, 384, DateTimeKind.Local).AddTicks(3004) },
                    { 7, "Amsterdam", new DateTime(2025, 2, 2, 9, 52, 46, 384, DateTimeKind.Local).AddTicks(3004) },
                    { 8, "Glasgow, Scotland", new DateTime(2025, 2, 2, 4, 52, 46, 384, DateTimeKind.Local).AddTicks(3004) },
                    { 9, "Zurich", new DateTime(2025, 2, 2, 2, 52, 46, 384, DateTimeKind.Local).AddTicks(3004) },
                    { 10, "Baku", new DateTime(2025, 2, 2, 9, 52, 46, 384, DateTimeKind.Local).AddTicks(3004) }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "Airline", "ArrivalId", "DepartureId", "Price", "RemainingNumberOfSeats" },
                values: new object[,]
                {
                    { 1, "American Airlines", 2, 1, "3543", 653 },
                    { 2, "Deutsche BA", 4, 3, "2027", 743 },
                    { 3, "British Airways", 6, 5, "2351", 240 },
                    { 4, "Basiq Air", 8, 7, "2207", 459 },
                    { 5, "BB Heliag", 10, 9, "1098", 331 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ArrivalId",
                table: "Flights",
                column: "ArrivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DepartureId",
                table: "Flights",
                column: "DepartureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Timeplaces");
        }
    }
}

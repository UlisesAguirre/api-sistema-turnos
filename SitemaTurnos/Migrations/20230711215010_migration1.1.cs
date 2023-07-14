using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class migration11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    NumberOfTable = table.Column<int>(type: "INTEGER", nullable: false),
                    Adress = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<double>(type: "REAL", nullable: false),
                    Starthour = table.Column<int>(type: "INTEGER", nullable: false),
                    Endhour = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservDuration = table.Column<int>(type: "INTEGER", nullable: false),
                    availableTables = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.Name);
                });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateReservation",
                value: new DateTime(2023, 7, 12, 18, 50, 10, 296, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateReservation",
                value: new DateTime(2023, 7, 13, 18, 50, 10, 296, DateTimeKind.Local).AddTicks(8483));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateReservation",
                value: new DateTime(2023, 7, 14, 18, 50, 10, 296, DateTimeKind.Local).AddTicks(8486));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateReservation",
                value: new DateTime(2023, 7, 15, 18, 50, 10, 296, DateTimeKind.Local).AddTicks(8487));

            migrationBuilder.InsertData(
                table: "Restaurant",
                columns: new[] { "Name", "Adress", "Endhour", "NumberOfTable", "Phone", "ReservDuration", "Starthour", "availableTables" },
                values: new object[] { "Pizzeria Paradiso", "paradiso@gmail.com", 0, 15, 3415122334.0, 2, 18, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateReservation",
                value: new DateTime(2023, 7, 12, 14, 16, 45, 386, DateTimeKind.Local).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateReservation",
                value: new DateTime(2023, 7, 13, 14, 16, 45, 386, DateTimeKind.Local).AddTicks(6332));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateReservation",
                value: new DateTime(2023, 7, 14, 14, 16, 45, 386, DateTimeKind.Local).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateReservation",
                value: new DateTime(2023, 7, 15, 14, 16, 45, 386, DateTimeKind.Local).AddTicks(6336));
        }
    }
}

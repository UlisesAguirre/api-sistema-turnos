using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class migration13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateReservation",
                value: new DateTime(2023, 7, 12, 21, 38, 2, 12, DateTimeKind.Local).AddTicks(6887));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateReservation",
                value: new DateTime(2023, 7, 13, 21, 38, 2, 12, DateTimeKind.Local).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateReservation",
                value: new DateTime(2023, 7, 14, 21, 38, 2, 12, DateTimeKind.Local).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateReservation",
                value: new DateTime(2023, 7, 15, 21, 38, 2, 12, DateTimeKind.Local).AddTicks(6916));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateReservation",
                value: new DateTime(2023, 7, 12, 19, 42, 50, 615, DateTimeKind.Local).AddTicks(3539));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateReservation",
                value: new DateTime(2023, 7, 13, 19, 42, 50, 615, DateTimeKind.Local).AddTicks(3564));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateReservation",
                value: new DateTime(2023, 7, 14, 19, 42, 50, 615, DateTimeKind.Local).AddTicks(3567));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateReservation",
                value: new DateTime(2023, 7, 15, 19, 42, 50, 615, DateTimeKind.Local).AddTicks(3569));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class migration16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateReservation", "ReservStatus" },
                values: new object[] { new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateReservation",
                value: new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateReservation", "ReservStatus" },
                values: new object[] { new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateReservation", "ReservStatus" },
                values: new object[] { new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateReservation", "ReservStatus" },
                values: new object[] { new DateTime(2023, 7, 15, 14, 47, 7, 765, DateTimeKind.Local).AddTicks(1494), 1 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateReservation",
                value: new DateTime(2023, 7, 16, 14, 47, 7, 765, DateTimeKind.Local).AddTicks(1517));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateReservation", "ReservStatus" },
                values: new object[] { new DateTime(2023, 7, 17, 14, 47, 7, 765, DateTimeKind.Local).AddTicks(1519), 1 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateReservation", "ReservStatus" },
                values: new object[] { new DateTime(2023, 7, 18, 14, 47, 7, 765, DateTimeKind.Local).AddTicks(1521), 1 });
        }
    }
}

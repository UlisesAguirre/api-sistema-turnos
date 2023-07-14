using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class migration12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "turn",
                table: "Reservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateReservation", "turn" },
                values: new object[] { new DateTime(2023, 7, 12, 19, 42, 50, 615, DateTimeKind.Local).AddTicks(3539), 0 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateReservation", "turn" },
                values: new object[] { new DateTime(2023, 7, 13, 19, 42, 50, 615, DateTimeKind.Local).AddTicks(3564), 1 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateReservation", "turn" },
                values: new object[] { new DateTime(2023, 7, 14, 19, 42, 50, 615, DateTimeKind.Local).AddTicks(3567), 2 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateReservation", "turn" },
                values: new object[] { new DateTime(2023, 7, 15, 19, 42, 50, 615, DateTimeKind.Local).AddTicks(3569), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "turn",
                table: "Reservations");

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
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class migration15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Disponibility",
                table: "TablesRestaurant",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateReservation",
                value: new DateTime(2023, 7, 15, 14, 47, 7, 765, DateTimeKind.Local).AddTicks(1494));

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
                column: "DateReservation",
                value: new DateTime(2023, 7, 17, 14, 47, 7, 765, DateTimeKind.Local).AddTicks(1519));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateReservation",
                value: new DateTime(2023, 7, 18, 14, 47, 7, 765, DateTimeKind.Local).AddTicks(1521));

            migrationBuilder.UpdateData(
                table: "TablesRestaurant",
                keyColumn: "Id",
                keyValue: 1,
                column: "Disponibility",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TablesRestaurant",
                keyColumn: "Id",
                keyValue: 2,
                column: "Disponibility",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TablesRestaurant",
                keyColumn: "Id",
                keyValue: 3,
                column: "Disponibility",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TablesRestaurant",
                keyColumn: "Id",
                keyValue: 4,
                column: "Disponibility",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponibility",
                table: "TablesRestaurant");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateReservation",
                value: new DateTime(2023, 7, 14, 22, 53, 33, 599, DateTimeKind.Local).AddTicks(5425));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateReservation",
                value: new DateTime(2023, 7, 15, 22, 53, 33, 599, DateTimeKind.Local).AddTicks(5447));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateReservation",
                value: new DateTime(2023, 7, 16, 22, 53, 33, 599, DateTimeKind.Local).AddTicks(5450));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateReservation",
                value: new DateTime(2023, 7, 17, 22, 53, 33, 599, DateTimeKind.Local).AddTicks(5452));
        }
    }
}

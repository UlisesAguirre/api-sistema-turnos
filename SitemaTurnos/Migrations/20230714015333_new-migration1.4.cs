using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class newmigration14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserType",
                value: "Client");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: 2);

            migrationBuilder.UpdateData(
                table: "TablesRestaurant",
                keyColumn: "Id",
                keyValue: 3,
                column: "Disponibility",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TablesRestaurant",
                keyColumn: "Id",
                keyValue: 4,
                column: "Disponibility",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserType",
                value: "Manager");
        }
    }
}

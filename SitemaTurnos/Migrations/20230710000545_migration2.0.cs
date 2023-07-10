using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class migration20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_TablesRestaurant_TableRestaurantId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TableRestaurantId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TableRestaurantId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "TablesRestaurant",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsersReservations",
                columns: table => new
                {
                    ReservationsDoneId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersReservations", x => new { x.ReservationsDoneId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UsersReservations_Reservations_ReservationsDoneId",
                        column: x => x.ReservationsDoneId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersReservations_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateReservation",
                value: new DateTime(2023, 7, 10, 21, 5, 45, 228, DateTimeKind.Local).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateReservation",
                value: new DateTime(2023, 7, 11, 21, 5, 45, 228, DateTimeKind.Local).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateReservation",
                value: new DateTime(2023, 7, 12, 21, 5, 45, 228, DateTimeKind.Local).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateReservation",
                value: new DateTime(2023, 7, 13, 21, 5, 45, 228, DateTimeKind.Local).AddTicks(8185));

            migrationBuilder.UpdateData(
                table: "TablesRestaurant",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReservationId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TablesRestaurant",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReservationId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TablesRestaurant",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReservationId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TablesRestaurant",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReservationId",
                value: null);

            migrationBuilder.InsertData(
                table: "UsersReservations",
                columns: new[] { "ReservationsDoneId", "UsersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TablesRestaurant_ReservationId",
                table: "TablesRestaurant",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersReservations_UsersId",
                table: "UsersReservations",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_TablesRestaurant_Reservations_ReservationId",
                table: "TablesRestaurant",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TablesRestaurant_Reservations_ReservationId",
                table: "TablesRestaurant");

            migrationBuilder.DropTable(
                name: "UsersReservations");

            migrationBuilder.DropIndex(
                name: "IX_TablesRestaurant_ReservationId",
                table: "TablesRestaurant");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "TablesRestaurant");

            migrationBuilder.AddColumn<int>(
                name: "TableRestaurantId",
                table: "Reservations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateReservation", "TableRestaurantId" },
                values: new object[] { new DateTime(2023, 6, 26, 19, 21, 27, 843, DateTimeKind.Local).AddTicks(3114), null });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateReservation", "TableRestaurantId" },
                values: new object[] { new DateTime(2023, 6, 27, 19, 21, 27, 843, DateTimeKind.Local).AddTicks(3133), null });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateReservation", "TableRestaurantId" },
                values: new object[] { new DateTime(2023, 6, 28, 19, 21, 27, 843, DateTimeKind.Local).AddTicks(3136), null });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateReservation", "TableRestaurantId" },
                values: new object[] { new DateTime(2023, 6, 29, 19, 21, 27, 843, DateTimeKind.Local).AddTicks(3137), null });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableRestaurantId",
                table: "Reservations",
                column: "TableRestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_TablesRestaurant_TableRestaurantId",
                table: "Reservations",
                column: "TableRestaurantId",
                principalTable: "TablesRestaurant",
                principalColumn: "Id");
        }
    }
}

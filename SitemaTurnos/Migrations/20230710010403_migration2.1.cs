using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class migration21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TablesRestaurant_Reservations_ReservationId",
                table: "TablesRestaurant");

            migrationBuilder.DropIndex(
                name: "IX_TablesRestaurant_ReservationId",
                table: "TablesRestaurant");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "TablesRestaurant");

            migrationBuilder.CreateTable(
                name: "TablesReservation",
                columns: table => new
                {
                    ReservationsAssignedId = table.Column<int>(type: "INTEGER", nullable: false),
                    TablesRestaurantId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablesReservation", x => new { x.ReservationsAssignedId, x.TablesRestaurantId });
                    table.ForeignKey(
                        name: "FK_TablesReservation_Reservations_ReservationsAssignedId",
                        column: x => x.ReservationsAssignedId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TablesReservation_TablesRestaurant_TablesRestaurantId",
                        column: x => x.TablesRestaurantId,
                        principalTable: "TablesRestaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateReservation",
                value: new DateTime(2023, 7, 10, 22, 4, 2, 977, DateTimeKind.Local).AddTicks(7871));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateReservation",
                value: new DateTime(2023, 7, 11, 22, 4, 2, 977, DateTimeKind.Local).AddTicks(7903));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateReservation",
                value: new DateTime(2023, 7, 12, 22, 4, 2, 977, DateTimeKind.Local).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateReservation",
                value: new DateTime(2023, 7, 13, 22, 4, 2, 977, DateTimeKind.Local).AddTicks(7908));

            migrationBuilder.InsertData(
                table: "TablesReservation",
                columns: new[] { "ReservationsAssignedId", "TablesRestaurantId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TablesReservation_TablesRestaurantId",
                table: "TablesReservation",
                column: "TablesRestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TablesReservation");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "TablesRestaurant",
                type: "INTEGER",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_TablesRestaurant_ReservationId",
                table: "TablesRestaurant",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TablesRestaurant_Reservations_ReservationId",
                table: "TablesRestaurant",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }
    }
}

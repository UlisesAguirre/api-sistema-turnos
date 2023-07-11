using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class migration10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TablesRestaurant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Disponibility = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablesRestaurant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    UserType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateReservation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NumOfPeople = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    TableId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_TablesRestaurant_TableId",
                        column: x => x.TableId,
                        principalTable: "TablesRestaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TablesRestaurant",
                columns: new[] { "Id", "Capacity", "Disponibility" },
                values: new object[,]
                {
                    { 1, 4, 0 },
                    { 2, 3, 2 },
                    { 3, 2, 1 },
                    { 4, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "UserType" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "Doe", "John", "1234", "Admin" },
                    { 2, "emma.smith@example.com", "Smith", "Emma", "1234", "Client" },
                    { 3, "michael.johnson@example.com", "Johnson", "Michael", "1234", "Client" },
                    { 4, "sophia.brown@example.com", "Brown", "Sophia", "1234", "Admin" },
                    { 5, "robert.lee@example.com", "Lee", "Robert", "1234", "Manager" },
                    { 6, "admin@gmail.com", "principal", "admin", "1234", "Admin" },
                    { 7, "client@example.com", "principal", "cliente", "1234", "Client" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "DateReservation", "NumOfPeople", "ReservStatus", "TableId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 12, 14, 16, 45, 386, DateTimeKind.Local).AddTicks(6309), 2, 1, 1, 1 },
                    { 2, new DateTime(2023, 7, 13, 14, 16, 45, 386, DateTimeKind.Local).AddTicks(6332), 4, 1, 2, 2 },
                    { 3, new DateTime(2023, 7, 14, 14, 16, 45, 386, DateTimeKind.Local).AddTicks(6335), 3, 1, 3, 3 },
                    { 4, new DateTime(2023, 7, 15, 14, 16, 45, 386, DateTimeKind.Local).AddTicks(6336), 6, 1, 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "TablesRestaurant");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

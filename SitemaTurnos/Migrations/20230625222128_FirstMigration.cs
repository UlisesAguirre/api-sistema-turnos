using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
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
                    IdTable = table.Column<int>(type: "INTEGER", nullable: false),
                    IdClient = table.Column<int>(type: "INTEGER", nullable: false),
                    TableRestaurantId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_TablesRestaurant_TableRestaurantId",
                        column: x => x.TableRestaurantId,
                        principalTable: "TablesRestaurant",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "DateReservation", "IdClient", "IdTable", "NumOfPeople", "ReservStatus", "TableRestaurantId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 26, 19, 21, 27, 843, DateTimeKind.Local).AddTicks(3114), 1, 1, 2, 1, null },
                    { 2, new DateTime(2023, 6, 27, 19, 21, 27, 843, DateTimeKind.Local).AddTicks(3133), 2, 2, 4, 1, null },
                    { 3, new DateTime(2023, 6, 28, 19, 21, 27, 843, DateTimeKind.Local).AddTicks(3136), 3, 3, 3, 1, null },
                    { 4, new DateTime(2023, 6, 29, 19, 21, 27, 843, DateTimeKind.Local).AddTicks(3137), 4, 4, 6, 1, null }
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
                    { 5, "robert.lee@example.com", "Lee", "Robert", "1234", "Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableRestaurantId",
                table: "Reservations",
                column: "TableRestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TablesRestaurant");
        }
    }
}

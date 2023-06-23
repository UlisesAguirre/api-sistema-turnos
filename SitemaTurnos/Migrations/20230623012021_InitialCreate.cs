using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SitemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}

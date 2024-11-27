using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagementApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "CreatedAt", "Description", "Priority", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0c9ba1cd-a294-4143-8f60-556564db58a6"), new DateTime(2024, 11, 27, 19, 51, 8, 631, DateTimeKind.Utc).AddTicks(887), "Descripción de la tarea inicial 2", 1, 1, "Tarea inicial 2", new DateTime(2024, 11, 27, 19, 51, 8, 631, DateTimeKind.Utc).AddTicks(887) },
                    { new Guid("30e75690-af6b-4273-ada3-b2b4456b2a5b"), new DateTime(2024, 11, 27, 19, 51, 8, 631, DateTimeKind.Utc).AddTicks(871), "Descripción de la tarea inicial 1", 0, 0, "Tarea inicial 1", new DateTime(2024, 11, 27, 19, 51, 8, 631, DateTimeKind.Utc).AddTicks(871) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: new Guid("0c9ba1cd-a294-4143-8f60-556564db58a6"));

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: new Guid("30e75690-af6b-4273-ada3-b2b4456b2a5b"));
        }
    }
}

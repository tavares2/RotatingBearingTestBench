using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RotatingBearingAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TestSequences",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Test Sequence 1" },
                    { 2, "Test Sequence 2" }
                });

            migrationBuilder.InsertData(
                table: "TestResults",
                columns: new[] { "Id", "RotationSpeed", "StressLevel", "Temperature", "TestSequenceId", "Timestamp" },
                values: new object[,]
                {
                    { 1, 1500.0, 8.5, 60.0, 1, new DateTime(2025, 3, 12, 16, 15, 28, 938, DateTimeKind.Utc).AddTicks(8485) },
                    { 2, 1200.0, 6.7000000000000002, 55.299999999999997, 2, new DateTime(2025, 3, 12, 16, 10, 28, 938, DateTimeKind.Utc).AddTicks(8662) }
                });

            migrationBuilder.InsertData(
                table: "TestSteps",
                columns: new[] { "Id", "Duration", "Setpoint", "StepNumber", "TestSequenceId" },
                values: new object[,]
                {
                    { 1, 10, 500.0, 1, 1 },
                    { 2, 15, 1000.0, 2, 1 },
                    { 3, 12, 800.0, 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TestResults",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TestResults",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TestSteps",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TestSteps",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TestSteps",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TestSequences",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TestSequences",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

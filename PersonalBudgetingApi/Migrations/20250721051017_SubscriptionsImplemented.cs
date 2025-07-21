using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalBudgetingApi.Migrations
{
    /// <inheritdoc />
    public partial class SubscriptionsImplemented : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subsccriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Frequency = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subsccriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subsccriptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Subsccriptions",
                columns: new[] { "Id", "Amount", "EndDate", "Frequency", "IsActive", "Name", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 1, 15.99m, null, "Monthly", false, "Netflix", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 9.99m, null, "Monthly", false, "Spotify", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 12.99m, null, "Monthly", false, "Amazon Prime", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 11.99m, null, "Monthly", false, "Hulu", new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subsccriptions_UserId_Name",
                table: "Subsccriptions",
                columns: new[] { "UserId", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subsccriptions");
        }
    }
}

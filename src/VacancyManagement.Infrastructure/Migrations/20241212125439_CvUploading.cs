using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VacancyManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CvUploading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: new Guid("017a9c4e-467f-4a18-bed3-6ca100eb6df9"));

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: new Guid("c37e1928-8519-4639-a0d5-c8f53ab239f2"));

            migrationBuilder.CreateTable(
                name: "ApplicantCVs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantCVs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantCVs_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Vacancies",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("bc2c5a13-6c81-44e3-b1ef-25c2074e55d6"), new DateTime(2024, 12, 12, 12, 54, 38, 22, DateTimeKind.Utc).AddTicks(6347), "Develop software solutions.", true, "Software Developer", null },
                    { new Guid("cbf7ee09-5195-4a6d-9b45-6a0c42133ef2"), new DateTime(2024, 12, 12, 12, 54, 38, 22, DateTimeKind.Utc).AddTicks(8108), "Manage sales activities.", true, "Sales Manager", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantCVs_ApplicantId",
                table: "ApplicantCVs",
                column: "ApplicantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantCVs");

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: new Guid("bc2c5a13-6c81-44e3-b1ef-25c2074e55d6"));

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: new Guid("cbf7ee09-5195-4a6d-9b45-6a0c42133ef2"));

            migrationBuilder.InsertData(
                table: "Vacancies",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("017a9c4e-467f-4a18-bed3-6ca100eb6df9"), new DateTime(2024, 12, 12, 8, 59, 28, 352, DateTimeKind.Utc).AddTicks(9724), "Manage sales activities.", true, "Sales Manager", null },
                    { new Guid("c37e1928-8519-4639-a0d5-c8f53ab239f2"), new DateTime(2024, 12, 12, 8, 59, 28, 352, DateTimeKind.Utc).AddTicks(8613), "Develop software solutions.", true, "Software Developer", null }
                });
        }
    }
}

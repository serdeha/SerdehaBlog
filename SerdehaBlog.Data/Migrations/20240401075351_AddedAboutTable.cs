using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerdehaBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedAboutTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 10, 53, 50, 802, DateTimeKind.Local).AddTicks(716), new DateTime(2024, 4, 1, 10, 53, 50, 802, DateTimeKind.Local).AddTicks(716), new DateTime(2024, 4, 1, 10, 53, 50, 802, DateTimeKind.Local).AddTicks(713) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 10, 53, 50, 802, DateTimeKind.Local).AddTicks(723), new DateTime(2024, 4, 1, 10, 53, 50, 802, DateTimeKind.Local).AddTicks(723), new DateTime(2024, 4, 1, 10, 53, 50, 802, DateTimeKind.Local).AddTicks(721) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89342532-fdef-4080-9bfa-c9160f218555", "AQAAAAIAAYagAAAAEG9LlTFB5If/tx3LBBcHluz4LE7aSJE5/lrVLGf2qyHxSjKLPqvT2c/0uA1tQ0zG/Q==", "2311fcd6-8575-4ddb-9020-85451a2e5d6e" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 10, 53, 50, 802, DateTimeKind.Local).AddTicks(2303), new DateTime(2024, 4, 1, 10, 53, 50, 802, DateTimeKind.Local).AddTicks(2304) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 10, 53, 50, 802, DateTimeKind.Local).AddTicks(2310), new DateTime(2024, 4, 1, 10, 53, 50, 802, DateTimeKind.Local).AddTicks(2310) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(6014), new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(6014), new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(6011) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(6019), new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(6020), new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(6018) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d7c99e3-004e-46b9-9080-ba459b781356", "AQAAAAIAAYagAAAAEPDQseTDKA4BFcsp8sMVirUlPPP91vI7hS1Z928Hba83cHBhAJUXK0JPqemq75YA+w==", "5e862c73-b25f-4fde-b985-f44f3462945a" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(7289), new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(7290) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(7293), new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(7294) });
        }
    }
}

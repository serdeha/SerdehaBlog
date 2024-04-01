using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerdehaBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedContactTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 2, 15, 50, 603, DateTimeKind.Local).AddTicks(6286), new DateTime(2024, 4, 1, 2, 15, 50, 603, DateTimeKind.Local).AddTicks(6287), new DateTime(2024, 4, 1, 2, 15, 50, 603, DateTimeKind.Local).AddTicks(6283) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 2, 15, 50, 603, DateTimeKind.Local).AddTicks(6292), new DateTime(2024, 4, 1, 2, 15, 50, 603, DateTimeKind.Local).AddTicks(6293), new DateTime(2024, 4, 1, 2, 15, 50, 603, DateTimeKind.Local).AddTicks(6291) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebbee4cb-3409-4931-9fae-65fdafcb08d6", "AQAAAAIAAYagAAAAEJKpYAcVNUtJKXbb05pmGZHfPUmWH8dyMtzB+XMCdFNYDg/hIjWR1OpK3Qs1GFwB6A==", "29fdff86-8707-4837-b52d-cca71fbb80f8" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 2, 15, 50, 604, DateTimeKind.Local).AddTicks(1112), new DateTime(2024, 4, 1, 2, 15, 50, 604, DateTimeKind.Local).AddTicks(1113) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 2, 15, 50, 604, DateTimeKind.Local).AddTicks(1117), new DateTime(2024, 4, 1, 2, 15, 50, 604, DateTimeKind.Local).AddTicks(1118) });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_AppUserId",
                table: "Contact",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 21, 22, 20, 0, 774, DateTimeKind.Local).AddTicks(7025), new DateTime(2024, 3, 21, 22, 20, 0, 774, DateTimeKind.Local).AddTicks(7026), new DateTime(2024, 3, 21, 22, 20, 0, 774, DateTimeKind.Local).AddTicks(7023) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 21, 22, 20, 0, 774, DateTimeKind.Local).AddTicks(7032), new DateTime(2024, 3, 21, 22, 20, 0, 774, DateTimeKind.Local).AddTicks(7033), new DateTime(2024, 3, 21, 22, 20, 0, 774, DateTimeKind.Local).AddTicks(7031) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ec0e8fe-4a97-4e1a-9b77-d14a69d75c1c", "AQAAAAIAAYagAAAAELrriQEEwsmiaAXzAbFbuIQONbwzkR8vH069DinJZ9FhZftS48CNtLEqXYIBm+EDOw==", "6dc2f695-4e2f-4404-9fe4-7171a38e9690" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 21, 22, 20, 0, 774, DateTimeKind.Local).AddTicks(9075), new DateTime(2024, 3, 21, 22, 20, 0, 774, DateTimeKind.Local).AddTicks(9076) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 21, 22, 20, 0, 774, DateTimeKind.Local).AddTicks(9080), new DateTime(2024, 3, 21, 22, 20, 0, 774, DateTimeKind.Local).AddTicks(9081) });
        }
    }
}

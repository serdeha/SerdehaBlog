using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerdehaBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedNotificationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 22, 15, 38, 5, 756, DateTimeKind.Local).AddTicks(3922), new DateTime(2024, 4, 22, 15, 38, 5, 756, DateTimeKind.Local).AddTicks(3922), new DateTime(2024, 4, 22, 15, 38, 5, 756, DateTimeKind.Local).AddTicks(3918) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 22, 15, 38, 5, 756, DateTimeKind.Local).AddTicks(3928), new DateTime(2024, 4, 22, 15, 38, 5, 756, DateTimeKind.Local).AddTicks(3929), new DateTime(2024, 4, 22, 15, 38, 5, 756, DateTimeKind.Local).AddTicks(3927) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "216ab5cf-3bf7-42be-a623-d5edae9af520", "AQAAAAIAAYagAAAAEKetOCWr+duMaCNQg1n/H61RL+R4719gbnNv1v4TmnIRnyKqeY4NwsxxyjnevIxCeQ==", "b088430b-f204-4093-b375-679e9e718751" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 22, 15, 38, 5, 756, DateTimeKind.Local).AddTicks(5880), new DateTime(2024, 4, 22, 15, 38, 5, 756, DateTimeKind.Local).AddTicks(5881) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 22, 15, 38, 5, 756, DateTimeKind.Local).AddTicks(5885), new DateTime(2024, 4, 22, 15, 38, 5, 756, DateTimeKind.Local).AddTicks(5886) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 20, 2, 30, 20, 332, DateTimeKind.Local).AddTicks(9587), new DateTime(2024, 4, 20, 2, 30, 20, 332, DateTimeKind.Local).AddTicks(9588), new DateTime(2024, 4, 20, 2, 30, 20, 332, DateTimeKind.Local).AddTicks(9583) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 20, 2, 30, 20, 332, DateTimeKind.Local).AddTicks(9595), new DateTime(2024, 4, 20, 2, 30, 20, 332, DateTimeKind.Local).AddTicks(9596), new DateTime(2024, 4, 20, 2, 30, 20, 332, DateTimeKind.Local).AddTicks(9593) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a42bf56-f078-4a03-a607-e4c2109c0126", "AQAAAAIAAYagAAAAEIkg1xCTsxqazu8exwKWbpgT66jLV460LQaIeHoNSlaSnHVdSekrYeRo3kHBmJ5png==", "43760d7b-746c-4ae0-a24b-ed57d7f6b6ae" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 20, 2, 30, 20, 333, DateTimeKind.Local).AddTicks(1540), new DateTime(2024, 4, 20, 2, 30, 20, 333, DateTimeKind.Local).AddTicks(1541) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 20, 2, 30, 20, 333, DateTimeKind.Local).AddTicks(1545), new DateTime(2024, 4, 20, 2, 30, 20, 333, DateTimeKind.Local).AddTicks(1546) });
        }
    }
}

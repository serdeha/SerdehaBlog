using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerdehaBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedNotificationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Notification",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 22, 16, 14, 19, 843, DateTimeKind.Local).AddTicks(6622), new DateTime(2024, 4, 22, 16, 14, 19, 843, DateTimeKind.Local).AddTicks(6622), new DateTime(2024, 4, 22, 16, 14, 19, 843, DateTimeKind.Local).AddTicks(6619) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 22, 16, 14, 19, 843, DateTimeKind.Local).AddTicks(6629), new DateTime(2024, 4, 22, 16, 14, 19, 843, DateTimeKind.Local).AddTicks(6629), new DateTime(2024, 4, 22, 16, 14, 19, 843, DateTimeKind.Local).AddTicks(6627) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85d7e806-e9c3-4e7f-8fc4-7b956acd2fad", "AQAAAAIAAYagAAAAED4fx2lGO2bHTn4vo1Vx5hSbnxvws+J6peSVxblLYTp2slXEBkKb1eHFksus/EuB8g==", "42d05197-713b-41f7-9310-c5189e694a1f" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 22, 16, 14, 19, 843, DateTimeKind.Local).AddTicks(8096), new DateTime(2024, 4, 22, 16, 14, 19, 843, DateTimeKind.Local).AddTicks(8097) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 22, 16, 14, 19, 843, DateTimeKind.Local).AddTicks(8100), new DateTime(2024, 4, 22, 16, 14, 19, 843, DateTimeKind.Local).AddTicks(8101) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Notification");

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
    }
}

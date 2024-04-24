using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerdehaBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedNotificationToCommentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Notification",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 24, 18, 44, 11, 619, DateTimeKind.Local).AddTicks(3817), new DateTime(2024, 4, 24, 18, 44, 11, 619, DateTimeKind.Local).AddTicks(3817), new DateTime(2024, 4, 24, 18, 44, 11, 619, DateTimeKind.Local).AddTicks(3812) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 24, 18, 44, 11, 619, DateTimeKind.Local).AddTicks(3826), new DateTime(2024, 4, 24, 18, 44, 11, 619, DateTimeKind.Local).AddTicks(3827), new DateTime(2024, 4, 24, 18, 44, 11, 619, DateTimeKind.Local).AddTicks(3824) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb3f59d0-19ab-482c-84aa-1d58d78312aa", "AQAAAAIAAYagAAAAEP6P/hUfqFt3MDAgNIZeHvTBZSArpDg4LDmxeKcAD3HSqbEOOORqudlWkmiR6U9m/A==", "474ca322-8495-487b-9ea3-89ee46938d6b" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 24, 18, 44, 11, 619, DateTimeKind.Local).AddTicks(5206), new DateTime(2024, 4, 24, 18, 44, 11, 619, DateTimeKind.Local).AddTicks(5207) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 24, 18, 44, 11, 619, DateTimeKind.Local).AddTicks(5214), new DateTime(2024, 4, 24, 18, 44, 11, 619, DateTimeKind.Local).AddTicks(5214) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Notification");

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
    }
}

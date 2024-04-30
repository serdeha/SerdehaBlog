using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerdehaBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class PublishedFinalized : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 29, 5, 19, 28, 458, DateTimeKind.Local).AddTicks(1029), new DateTime(2024, 4, 29, 5, 19, 28, 458, DateTimeKind.Local).AddTicks(1030), new DateTime(2024, 4, 29, 5, 19, 28, 458, DateTimeKind.Local).AddTicks(1027) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 29, 5, 19, 28, 458, DateTimeKind.Local).AddTicks(1035), new DateTime(2024, 4, 29, 5, 19, 28, 458, DateTimeKind.Local).AddTicks(1036), new DateTime(2024, 4, 29, 5, 19, 28, 458, DateTimeKind.Local).AddTicks(1034) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab68b9af-dae8-4782-b5e3-e0efbcdcf806", "AQAAAAIAAYagAAAAEJITumkZTM+O/odwtpvJJwuJRhyVYkjuaEtqWttH8nVAfYApkklSu5Tx6gm0SMHNtA==", "58beddfb-fb46-4e62-abd7-a9996899fed3" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 29, 5, 19, 28, 458, DateTimeKind.Local).AddTicks(2283), new DateTime(2024, 4, 29, 5, 19, 28, 458, DateTimeKind.Local).AddTicks(2284) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 29, 5, 19, 28, 458, DateTimeKind.Local).AddTicks(2287), new DateTime(2024, 4, 29, 5, 19, 28, 458, DateTimeKind.Local).AddTicks(2288) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}

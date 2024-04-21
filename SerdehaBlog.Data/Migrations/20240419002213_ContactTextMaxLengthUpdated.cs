using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerdehaBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class ContactTextMaxLengthUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Contact",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 19, 3, 22, 13, 97, DateTimeKind.Local).AddTicks(1536), new DateTime(2024, 4, 19, 3, 22, 13, 97, DateTimeKind.Local).AddTicks(1536), new DateTime(2024, 4, 19, 3, 22, 13, 97, DateTimeKind.Local).AddTicks(1528) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 19, 3, 22, 13, 97, DateTimeKind.Local).AddTicks(1545), new DateTime(2024, 4, 19, 3, 22, 13, 97, DateTimeKind.Local).AddTicks(1545), new DateTime(2024, 4, 19, 3, 22, 13, 97, DateTimeKind.Local).AddTicks(1543) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70608af9-b2e3-465d-aad6-62c0331b5ba5", "AQAAAAIAAYagAAAAEFQFfvueOZO5jEQcPBfppzhs1M2k/nAZEx5E7Zc3IBZytkzAMZQAVoWcPiTJuHqkDw==", "c1870924-3b5c-42cc-a483-f7fb4999b752" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 19, 3, 22, 13, 97, DateTimeKind.Local).AddTicks(3223), new DateTime(2024, 4, 19, 3, 22, 13, 97, DateTimeKind.Local).AddTicks(3224) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 19, 3, 22, 13, 97, DateTimeKind.Local).AddTicks(3228), new DateTime(2024, 4, 19, 3, 22, 13, 97, DateTimeKind.Local).AddTicks(3229) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Contact",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 2, 6, 56, 29, 959, DateTimeKind.Local).AddTicks(3347), new DateTime(2024, 4, 2, 6, 56, 29, 959, DateTimeKind.Local).AddTicks(3347), new DateTime(2024, 4, 2, 6, 56, 29, 959, DateTimeKind.Local).AddTicks(3345) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 2, 6, 56, 29, 959, DateTimeKind.Local).AddTicks(3353), new DateTime(2024, 4, 2, 6, 56, 29, 959, DateTimeKind.Local).AddTicks(3353), new DateTime(2024, 4, 2, 6, 56, 29, 959, DateTimeKind.Local).AddTicks(3352) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2976d2ff-ee4f-432d-85ff-c06efed6ca01", "AQAAAAIAAYagAAAAEEYrWpuzZfwwUU0tuJR7ZmGsAEWSENtcQELQX3qIyiyw8Q4YD1Qey60qojnOXnSRew==", "7f751c3a-5065-4d44-ad73-311e14b62630" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 2, 6, 56, 29, 959, DateTimeKind.Local).AddTicks(4581), new DateTime(2024, 4, 2, 6, 56, 29, 959, DateTimeKind.Local).AddTicks(4582) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 2, 6, 56, 29, 959, DateTimeKind.Local).AddTicks(4585), new DateTime(2024, 4, 2, 6, 56, 29, 959, DateTimeKind.Local).AddTicks(4586) });
        }
    }
}

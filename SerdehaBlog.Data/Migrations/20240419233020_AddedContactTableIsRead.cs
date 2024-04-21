using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerdehaBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedContactTableIsRead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Contact",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Contact");

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
    }
}

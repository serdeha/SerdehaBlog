using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerdehaBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class ArticleTableAddedIsCarousel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCorousel",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "IsCorousel", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 21, 22, 20, 0, 774, DateTimeKind.Local).AddTicks(7025), new DateTime(2024, 3, 21, 22, 20, 0, 774, DateTimeKind.Local).AddTicks(7026), false, new DateTime(2024, 3, 21, 22, 20, 0, 774, DateTimeKind.Local).AddTicks(7023) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "IsCorousel", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 21, 22, 20, 0, 774, DateTimeKind.Local).AddTicks(7032), new DateTime(2024, 3, 21, 22, 20, 0, 774, DateTimeKind.Local).AddTicks(7033), false, new DateTime(2024, 3, 21, 22, 20, 0, 774, DateTimeKind.Local).AddTicks(7031) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorousel",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 9, 23, 15, 31, 743, DateTimeKind.Local).AddTicks(7740), new DateTime(2024, 3, 9, 23, 15, 31, 743, DateTimeKind.Local).AddTicks(7741), new DateTime(2024, 3, 9, 23, 15, 31, 743, DateTimeKind.Local).AddTicks(7737) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 9, 23, 15, 31, 743, DateTimeKind.Local).AddTicks(7749), new DateTime(2024, 3, 9, 23, 15, 31, 743, DateTimeKind.Local).AddTicks(7750), new DateTime(2024, 3, 9, 23, 15, 31, 743, DateTimeKind.Local).AddTicks(7748) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d136cedb-bf16-4b43-92bc-3be062242f2f", "AQAAAAIAAYagAAAAEF5jMJhrwie0kdXsMyafwL1BX1aL+7L7IoIQLIIJ7NYEgM+h6BaO7OqhkgTcqCVk5w==", "3a773337-bf79-4980-8b37-2e662cdf4216" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 9, 23, 15, 31, 744, DateTimeKind.Local).AddTicks(619), new DateTime(2024, 3, 9, 23, 15, 31, 744, DateTimeKind.Local).AddTicks(621) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 9, 23, 15, 31, 744, DateTimeKind.Local).AddTicks(624), new DateTime(2024, 3, 9, 23, 15, 31, 744, DateTimeKind.Local).AddTicks(626) });
        }
    }
}

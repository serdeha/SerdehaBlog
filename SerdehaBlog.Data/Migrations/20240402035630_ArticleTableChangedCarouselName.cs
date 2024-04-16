using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerdehaBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class ArticleTableChangedCarouselName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCorousel",
                table: "Articles",
                newName: "IsCarousel");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCarousel",
                table: "Articles",
                newName: "IsCorousel");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 11, 1, 50, 970, DateTimeKind.Local).AddTicks(4737), new DateTime(2024, 4, 1, 11, 1, 50, 970, DateTimeKind.Local).AddTicks(4737), new DateTime(2024, 4, 1, 11, 1, 50, 970, DateTimeKind.Local).AddTicks(4734) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 11, 1, 50, 970, DateTimeKind.Local).AddTicks(4744), new DateTime(2024, 4, 1, 11, 1, 50, 970, DateTimeKind.Local).AddTicks(4744), new DateTime(2024, 4, 1, 11, 1, 50, 970, DateTimeKind.Local).AddTicks(4742) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3b352df-4756-4db4-a84c-0fbe5c8a3c0d", "AQAAAAIAAYagAAAAECcteVzOBgKZCf0Om0ykdq1Lt6UbwlZyr4YmbLnljId7LMihPeGE5YXNSpLeYCLYMw==", "3410888f-66e1-4ea7-80a9-2a930f7e38f4" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 11, 1, 50, 970, DateTimeKind.Local).AddTicks(6134), new DateTime(2024, 4, 1, 11, 1, 50, 970, DateTimeKind.Local).AddTicks(6135) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 11, 1, 50, 970, DateTimeKind.Local).AddTicks(6139), new DateTime(2024, 4, 1, 11, 1, 50, 970, DateTimeKind.Local).AddTicks(6140) });
        }
    }
}

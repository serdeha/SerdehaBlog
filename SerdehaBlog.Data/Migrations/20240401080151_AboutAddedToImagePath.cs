using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerdehaBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class AboutAddedToImagePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "About",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "About");

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
    }
}

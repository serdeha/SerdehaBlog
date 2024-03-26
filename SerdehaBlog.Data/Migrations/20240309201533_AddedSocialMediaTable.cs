using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerdehaBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSocialMediaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_AppUserId",
                table: "Articles");

            migrationBuilder.CreateTable(
                name: "SocialMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_SocialMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMedia_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedia_AppUserId",
                table: "SocialMedia",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_AppUserId",
                table: "Articles",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_AppUserId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "SocialMedia");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 7, 16, 50, 21, 707, DateTimeKind.Local).AddTicks(6826), new DateTime(2024, 3, 7, 16, 50, 21, 707, DateTimeKind.Local).AddTicks(6827), new DateTime(2024, 3, 7, 16, 50, 21, 707, DateTimeKind.Local).AddTicks(6825) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 7, 16, 50, 21, 707, DateTimeKind.Local).AddTicks(6834), new DateTime(2024, 3, 7, 16, 50, 21, 707, DateTimeKind.Local).AddTicks(6834), new DateTime(2024, 3, 7, 16, 50, 21, 707, DateTimeKind.Local).AddTicks(6833) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9cfe51e-73a4-4707-a60f-162286866b6f", "AQAAAAIAAYagAAAAEFvqj9NdCL4GTAtwWYzRWogQh3NHy+1Cj11sLhZN/R5jU7Zbdnll9jsr5hHgHQTRVQ==", "b41b6513-6e3b-4d89-bb67-7b8f5f903735" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 7, 16, 50, 21, 707, DateTimeKind.Local).AddTicks(8385), new DateTime(2024, 3, 7, 16, 50, 21, 707, DateTimeKind.Local).AddTicks(8387) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 7, 16, 50, 21, 707, DateTimeKind.Local).AddTicks(8389), new DateTime(2024, 3, 7, 16, 50, 21, 707, DateTimeKind.Local).AddTicks(8390) });

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_AppUserId",
                table: "Articles",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

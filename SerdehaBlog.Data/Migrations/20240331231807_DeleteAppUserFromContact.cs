using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerdehaBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteAppUserFromContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_AspNetUsers_AppUserId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_AppUserId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Contact");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(6014), new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(6014), new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(6011) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(6019), new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(6020), new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(6018) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d7c99e3-004e-46b9-9080-ba459b781356", "AQAAAAIAAYagAAAAEPDQseTDKA4BFcsp8sMVirUlPPP91vI7hS1Z928Hba83cHBhAJUXK0JPqemq75YA+w==", "5e862c73-b25f-4fde-b985-f44f3462945a" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(7289), new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(7290) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(7293), new DateTime(2024, 4, 1, 2, 18, 6, 859, DateTimeKind.Local).AddTicks(7294) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Contact",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 2, 15, 50, 603, DateTimeKind.Local).AddTicks(6286), new DateTime(2024, 4, 1, 2, 15, 50, 603, DateTimeKind.Local).AddTicks(6287), new DateTime(2024, 4, 1, 2, 15, 50, 603, DateTimeKind.Local).AddTicks(6283) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 2, 15, 50, 603, DateTimeKind.Local).AddTicks(6292), new DateTime(2024, 4, 1, 2, 15, 50, 603, DateTimeKind.Local).AddTicks(6293), new DateTime(2024, 4, 1, 2, 15, 50, 603, DateTimeKind.Local).AddTicks(6291) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebbee4cb-3409-4931-9fae-65fdafcb08d6", "AQAAAAIAAYagAAAAEJKpYAcVNUtJKXbb05pmGZHfPUmWH8dyMtzB+XMCdFNYDg/hIjWR1OpK3Qs1GFwB6A==", "29fdff86-8707-4837-b52d-cca71fbb80f8" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 2, 15, 50, 604, DateTimeKind.Local).AddTicks(1112), new DateTime(2024, 4, 1, 2, 15, 50, 604, DateTimeKind.Local).AddTicks(1113) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 2, 15, 50, 604, DateTimeKind.Local).AddTicks(1117), new DateTime(2024, 4, 1, 2, 15, 50, 604, DateTimeKind.Local).AddTicks(1118) });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_AppUserId",
                table: "Contact",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_AspNetUsers_AppUserId",
                table: "Contact",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

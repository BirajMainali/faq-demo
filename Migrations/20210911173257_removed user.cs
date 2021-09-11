using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FAQ.Migrations
{
    public partial class removeduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_faq_items_auth_user_UserId",
                schema: "faq",
                table: "faq_items");

            migrationBuilder.DropTable(
                name: "auth_user",
                schema: "User");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "faq",
                table: "tags",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RecDate",
                value: new DateTime(2021, 9, 11, 23, 17, 57, 380, DateTimeKind.Local).AddTicks(4003));

            migrationBuilder.UpdateData(
                schema: "faq",
                table: "tags",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RecDate",
                value: new DateTime(2021, 9, 11, 23, 17, 57, 381, DateTimeKind.Local).AddTicks(273));

            migrationBuilder.UpdateData(
                schema: "faq",
                table: "tags",
                keyColumn: "Id",
                keyValue: 3L,
                column: "RecDate",
                value: new DateTime(2021, 9, 11, 23, 17, 57, 381, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.AddForeignKey(
                name: "FK_faq_items_AspNetUsers_UserId",
                schema: "faq",
                table: "faq_items",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_faq_items_AspNetUsers_UserId",
                schema: "faq",
                table: "faq_items");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.CreateTable(
                name: "auth_user",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_auth_user_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "faq",
                table: "tags",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RecDate",
                value: new DateTime(2021, 9, 11, 21, 48, 38, 178, DateTimeKind.Local).AddTicks(9437));

            migrationBuilder.UpdateData(
                schema: "faq",
                table: "tags",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RecDate",
                value: new DateTime(2021, 9, 11, 21, 48, 38, 179, DateTimeKind.Local).AddTicks(5602));

            migrationBuilder.UpdateData(
                schema: "faq",
                table: "tags",
                keyColumn: "Id",
                keyValue: 3L,
                column: "RecDate",
                value: new DateTime(2021, 9, 11, 21, 48, 38, 179, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.AddForeignKey(
                name: "FK_faq_items_auth_user_UserId",
                schema: "faq",
                table: "faq_items",
                column: "UserId",
                principalSchema: "User",
                principalTable: "auth_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

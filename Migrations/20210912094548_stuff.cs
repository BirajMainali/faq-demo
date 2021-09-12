using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FAQ.Migrations
{
    public partial class stuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "faq",
                table: "tags",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RecDate",
                value: new DateTime(2021, 9, 12, 15, 30, 48, 535, DateTimeKind.Local).AddTicks(9269));

            migrationBuilder.UpdateData(
                schema: "faq",
                table: "tags",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RecDate",
                value: new DateTime(2021, 9, 12, 15, 30, 48, 536, DateTimeKind.Local).AddTicks(5354));

            migrationBuilder.UpdateData(
                schema: "faq",
                table: "tags",
                keyColumn: "Id",
                keyValue: 3L,
                column: "RecDate",
                value: new DateTime(2021, 9, 12, 15, 30, 48, 536, DateTimeKind.Local).AddTicks(5366));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "faq",
                table: "tags",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RecDate",
                value: new DateTime(2021, 9, 12, 13, 12, 11, 576, DateTimeKind.Local).AddTicks(1393));

            migrationBuilder.UpdateData(
                schema: "faq",
                table: "tags",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RecDate",
                value: new DateTime(2021, 9, 12, 13, 12, 11, 576, DateTimeKind.Local).AddTicks(7692));

            migrationBuilder.UpdateData(
                schema: "faq",
                table: "tags",
                keyColumn: "Id",
                keyValue: 3L,
                column: "RecDate",
                value: new DateTime(2021, 9, 12, 13, 12, 11, 576, DateTimeKind.Local).AddTicks(7704));
        }
    }
}

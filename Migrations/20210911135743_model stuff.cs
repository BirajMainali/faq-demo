using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FAQ.Migrations
{
    public partial class modelstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                schema: "FAQ",
                table: "FAQ");

            migrationBuilder.CreateTable(
                name: "tag",
                schema: "FAQ",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    RecDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ChangeAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RecAuditLog = table.Column<string>(type: "text", nullable: true),
                    RecStatus = table.Column<char>(type: "character(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "faq_tag",
                schema: "FAQ",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TagId = table.Column<long>(type: "bigint", nullable: true),
                    FaqId = table.Column<long>(type: "bigint", nullable: true),
                    RecDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ChangeAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RecAuditLog = table.Column<string>(type: "text", nullable: true),
                    RecStatus = table.Column<char>(type: "character(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faq_tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_faq_tag_FAQ_FaqId",
                        column: x => x.FaqId,
                        principalSchema: "FAQ",
                        principalTable: "FAQ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_faq_tag_tag_TagId",
                        column: x => x.TagId,
                        principalSchema: "FAQ",
                        principalTable: "tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "FAQ",
                table: "tag",
                columns: new[] { "Id", "ChangeAt", "RecAuditLog", "RecDate", "RecStatus", "Slug" },
                values: new object[,]
                {
                    { 1L, null, null, new DateTime(2021, 9, 11, 19, 42, 43, 295, DateTimeKind.Local).AddTicks(4693), 'A', "Stakeholder" },
                    { 2L, null, null, new DateTime(2021, 9, 11, 19, 42, 43, 296, DateTimeKind.Local).AddTicks(1055), 'A', "Inventory" },
                    { 3L, null, null, new DateTime(2021, 9, 11, 19, 42, 43, 296, DateTimeKind.Local).AddTicks(1073), 'A', "Web" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_faq_tag_FaqId",
                schema: "FAQ",
                table: "faq_tag",
                column: "FaqId");

            migrationBuilder.CreateIndex(
                name: "IX_faq_tag_TagId",
                schema: "FAQ",
                table: "faq_tag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "faq_tag",
                schema: "FAQ");

            migrationBuilder.DropTable(
                name: "tag",
                schema: "FAQ");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                schema: "FAQ",
                table: "FAQ",
                type: "text",
                nullable: true);
        }
    }
}

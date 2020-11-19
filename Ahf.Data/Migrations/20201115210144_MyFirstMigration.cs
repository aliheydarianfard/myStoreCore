using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahf.Data.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    DiscountAmount = table.Column<int>(type: "int", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Category",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "CreateOn", "DiscountAmount", "Name", "ParentId", "UpdateOn" },
                values: new object[] { 1, new DateTime(2020, 11, 16, 0, 31, 44, 492, DateTimeKind.Local).AddTicks(3107), 0, "دسته", 1, new DateTime(2020, 11, 16, 0, 31, 44, 496, DateTimeKind.Local).AddTicks(328) });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                table: "Category",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}

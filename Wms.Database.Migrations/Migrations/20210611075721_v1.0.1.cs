using Microsoft.EntityFrameworkCore.Migrations;

namespace Wms.Database.Migrations.Migrations
{
    public partial class v101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070911602L,
                column: "Component",
                value: "system/log/vislog");

            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070911605L,
                column: "Component",
                value: "system/log/oplog");

            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070911608L,
                column: "Component",
                value: "system/log/exlog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070911602L,
                column: "Component",
                value: "system/log/vislog/index");

            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070911605L,
                column: "Component",
                value: "system/log/oplog/index");

            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070911608L,
                column: "Component",
                value: "system/log/exlog/index");
        }
    }
}

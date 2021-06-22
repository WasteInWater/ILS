using Microsoft.EntityFrameworkCore.Migrations;

namespace Wms.Database.Migrations.Migrations
{
    public partial class v102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070911502L,
                column: "Component",
                value: "system/monitor/machine");

            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070911504L,
                column: "Component",
                value: "system/monitor/onlineUser");

            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070911507L,
                column: "Component",
                value: "system/monitor/druid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070911502L,
                column: "Component",
                value: "system/machine/index");

            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070911504L,
                column: "Component",
                value: "system/onlineUser/index");

            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070911507L,
                column: "Component",
                value: "system/druid/index");
        }
    }
}

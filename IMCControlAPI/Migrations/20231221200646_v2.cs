using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMCControlAPI.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IMCOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Max",
                value: 18.399999999999999);

            migrationBuilder.UpdateData(
                table: "IMCOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Max",
                value: 29.899999999999999);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IMCOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Max",
                value: 18.5);

            migrationBuilder.UpdateData(
                table: "IMCOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Max",
                value: 28.899999999999999);
        }
    }
}

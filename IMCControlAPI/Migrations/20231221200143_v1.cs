using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMCControlAPI.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "IMCOptions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "IMCOptions",
                columns: new[] { "Id", "Color", "Description", "Max", "Min" },
                values: new object[] { 1, "#DAD82A", "Peso inferior al normal", 18.5, 0.0 });

            migrationBuilder.InsertData(
                table: "IMCOptions",
                columns: new[] { "Id", "Color", "Description", "Max", "Min" },
                values: new object[] { 2, "#24BD21", "Peso normal", 24.899999999999999, 18.5 });

            migrationBuilder.InsertData(
                table: "IMCOptions",
                columns: new[] { "Id", "Color", "Description", "Max", "Min" },
                values: new object[] { 3, "#CB740B", "Peso superior al normal", 28.899999999999999, 25.0 });

            migrationBuilder.InsertData(
                table: "IMCOptions",
                columns: new[] { "Id", "Color", "Description", "Max", "Min" },
                values: new object[] { 4, "#D50C0C", "Obesidad", 99.0, 30.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IMCOptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IMCOptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IMCOptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IMCOptions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Color",
                table: "IMCOptions");
        }
    }
}

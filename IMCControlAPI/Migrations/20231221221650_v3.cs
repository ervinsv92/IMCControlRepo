using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMCControlAPI.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImcColor",
                table: "IMCUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImcColor",
                table: "IMCUsers");
        }
    }
}

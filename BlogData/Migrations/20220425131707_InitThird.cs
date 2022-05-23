using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogData.Migrations
{
    public partial class InitThird : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Remember",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remember",
                table: "AspNetUsers");
        }
    }
}

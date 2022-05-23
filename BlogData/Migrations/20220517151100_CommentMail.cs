using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogData.Migrations
{
    public partial class CommentMail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentMail",
                table: "Comments",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentMail",
                table: "Comments");
        }
    }
}

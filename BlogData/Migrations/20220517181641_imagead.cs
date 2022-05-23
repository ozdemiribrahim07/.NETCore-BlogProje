using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogData.Migrations
{
    public partial class imagead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArticleImageName",
                table: "Articles",
                newName: "ArticleImage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArticleImage",
                table: "Articles",
                newName: "ArticleImageName");
        }
    }
}

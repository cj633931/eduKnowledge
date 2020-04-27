using Microsoft.EntityFrameworkCore.Migrations;

namespace eduKnowledge.Data.Migrations
{
    public partial class RemovedTagRequiringArticleId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Articles_ArticleId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ArticleId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Tags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ArticleId",
                table: "Tags",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Articles_ArticleId",
                table: "Tags",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

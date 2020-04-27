using Microsoft.EntityFrameworkCore.Migrations;

namespace eduKnowledge.Data.Migrations
{
    public partial class AddedTaggedArticlesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaggedArticles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaggedArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaggedArticles_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaggedArticles_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaggedArticles_ArticleId",
                table: "TaggedArticles",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_TaggedArticles_TagId",
                table: "TaggedArticles",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaggedArticles");
        }
    }
}

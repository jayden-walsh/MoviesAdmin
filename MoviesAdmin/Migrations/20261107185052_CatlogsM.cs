using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesAdmin.Migrations
{
    /// <inheritdoc />
    public partial class CatlogsM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorycatlogId",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "catlogs",
                columns: table => new
                {
                    catlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catlogs", x => x.catlogId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CategorycatlogId",
                table: "Movie",
                column: "CategorycatlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_catlogs_CategorycatlogId",
                table: "Movie",
                column: "CategorycatlogId",
                principalTable: "catlogs",
                principalColumn: "catlogId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_catlogs_CategorycatlogId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "catlogs");

            migrationBuilder.DropIndex(
                name: "IX_Movie_CategorycatlogId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "CategorycatlogId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Movie");
        }
    }
}

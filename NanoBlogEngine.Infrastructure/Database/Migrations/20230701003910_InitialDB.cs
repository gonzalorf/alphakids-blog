using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NanoBlogEngine.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class InitialDB : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(
            name: "Categories",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Categories", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "Posts",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Preview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Posts", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Users", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "CategoryPost",
            columns: table => new
            {
                CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_CategoryPost", x => new { x.CategoriesId, x.PostId });
                _ = table.ForeignKey(
                    name: "FK_CategoryPost_Categories_CategoriesId",
                    column: x => x.CategoriesId,
                    principalTable: "Categories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_CategoryPost_Posts_PostId",
                    column: x => x.PostId,
                    principalTable: "Posts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "Comments",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Comments", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_Comments_Posts_PostId",
                    column: x => x.PostId,
                    principalTable: "Posts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_Comments_Users_AuthorId",
                    column: x => x.AuthorId,
                    principalTable: "Users",
                    principalColumn: "Id");
            });

        _ = migrationBuilder.CreateTable(
            name: "Rates",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Value = table.Column<int>(type: "int", nullable: false),
                RaterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Rates", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_Rates_Posts_PostId",
                    column: x => x.PostId,
                    principalTable: "Posts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_Rates_Users_RaterId",
                    column: x => x.RaterId,
                    principalTable: "Users",
                    principalColumn: "Id");
            });

        _ = migrationBuilder.CreateIndex(
            name: "IX_CategoryPost_PostId",
            table: "CategoryPost",
            column: "PostId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Comments_AuthorId",
            table: "Comments",
            column: "AuthorId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Comments_PostId",
            table: "Comments",
            column: "PostId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Rates_PostId",
            table: "Rates",
            column: "PostId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Rates_RaterId",
            table: "Rates",
            column: "RaterId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "CategoryPost");

        _ = migrationBuilder.DropTable(
            name: "Comments");

        _ = migrationBuilder.DropTable(
            name: "Rates");

        _ = migrationBuilder.DropTable(
            name: "Categories");

        _ = migrationBuilder.DropTable(
            name: "Posts");

        _ = migrationBuilder.DropTable(
            name: "Users");
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NanoBlogEngine.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AuditableTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Rates",
                newName: "Rates",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Posts",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comments",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CategoryPost",
                newName: "CategoryPost",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categories",
                newSchema: "dbo");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "dbo",
                table: "Posts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "dbo",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                schema: "dbo",
                table: "Posts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "dbo",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OutboxMessages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OccurredOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Error = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutboxMessages",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "dbo",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Updated",
                schema: "dbo",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "dbo",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "dbo",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Rates",
                schema: "dbo",
                newName: "Rates");

            migrationBuilder.RenameTable(
                name: "Posts",
                schema: "dbo",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "Comments",
                schema: "dbo",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "CategoryPost",
                schema: "dbo",
                newName: "CategoryPost");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "dbo",
                newName: "Categories");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NanoBlogEngine.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class AuditableTables : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.EnsureSchema(
            name: "dbo");

        _ = migrationBuilder.RenameTable(
            name: "Users",
            newName: "Users",
            newSchema: "dbo");

        _ = migrationBuilder.RenameTable(
            name: "Rates",
            newName: "Rates",
            newSchema: "dbo");

        _ = migrationBuilder.RenameTable(
            name: "Posts",
            newName: "Posts",
            newSchema: "dbo");

        _ = migrationBuilder.RenameTable(
            name: "Comments",
            newName: "Comments",
            newSchema: "dbo");

        _ = migrationBuilder.RenameTable(
            name: "CategoryPost",
            newName: "CategoryPost",
            newSchema: "dbo");

        _ = migrationBuilder.RenameTable(
            name: "Categories",
            newName: "Categories",
            newSchema: "dbo");

        _ = migrationBuilder.AddColumn<DateTime>(
            name: "Created",
            schema: "dbo",
            table: "Posts",
            type: "datetime2",
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "CreatedBy",
            schema: "dbo",
            table: "Posts",
            type: "nvarchar(max)",
            nullable: true);

        _ = migrationBuilder.AddColumn<DateTime>(
            name: "Updated",
            schema: "dbo",
            table: "Posts",
            type: "datetime2",
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "UpdatedBy",
            schema: "dbo",
            table: "Posts",
            type: "nvarchar(max)",
            nullable: true);

        _ = migrationBuilder.CreateTable(
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
                _ = table.PrimaryKey("PK_OutboxMessages", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "OutboxMessages",
            schema: "dbo");

        _ = migrationBuilder.DropColumn(
            name: "Created",
            schema: "dbo",
            table: "Posts");

        _ = migrationBuilder.DropColumn(
            name: "CreatedBy",
            schema: "dbo",
            table: "Posts");

        _ = migrationBuilder.DropColumn(
            name: "Updated",
            schema: "dbo",
            table: "Posts");

        _ = migrationBuilder.DropColumn(
            name: "UpdatedBy",
            schema: "dbo",
            table: "Posts");

        _ = migrationBuilder.RenameTable(
            name: "Users",
            schema: "dbo",
            newName: "Users");

        _ = migrationBuilder.RenameTable(
            name: "Rates",
            schema: "dbo",
            newName: "Rates");

        _ = migrationBuilder.RenameTable(
            name: "Posts",
            schema: "dbo",
            newName: "Posts");

        _ = migrationBuilder.RenameTable(
            name: "Comments",
            schema: "dbo",
            newName: "Comments");

        _ = migrationBuilder.RenameTable(
            name: "CategoryPost",
            schema: "dbo",
            newName: "CategoryPost");

        _ = migrationBuilder.RenameTable(
            name: "Categories",
            schema: "dbo",
            newName: "Categories");
    }
}

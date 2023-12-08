using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NanoBlogEngine.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Migra01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_AuthorId",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Posts_PostId",
                schema: "dbo",
                table: "Rates");

            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Users_RaterId",
                schema: "dbo",
                table: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_Rates_PostId",
                schema: "dbo",
                table: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_Rates_RaterId",
                schema: "dbo",
                table: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AuthorId",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostId",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.AlterColumn<Guid>(
                name: "RaterId",
                schema: "dbo",
                table: "Rates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                schema: "dbo",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "RaterId",
                schema: "dbo",
                table: "Rates",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                schema: "dbo",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_PostId",
                schema: "dbo",
                table: "Rates",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_RaterId",
                schema: "dbo",
                table: "Rates",
                column: "RaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                schema: "dbo",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                schema: "dbo",
                table: "Comments",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                schema: "dbo",
                table: "Comments",
                column: "PostId",
                principalSchema: "dbo",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_AuthorId",
                schema: "dbo",
                table: "Comments",
                column: "AuthorId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Posts_PostId",
                schema: "dbo",
                table: "Rates",
                column: "PostId",
                principalSchema: "dbo",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Users_RaterId",
                schema: "dbo",
                table: "Rates",
                column: "RaterId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniLotto.API.Migrations
{
    /// <inheritdoc />
    public partial class PlayerNumberSetsIIToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NumberSet_Players_PlayerId",
                table: "NumberSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NumberSet",
                table: "NumberSet");

            migrationBuilder.RenameTable(
                name: "NumberSet",
                newName: "NumberSets");

            migrationBuilder.RenameIndex(
                name: "IX_NumberSet_PlayerId",
                table: "NumberSets",
                newName: "IX_NumberSets_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NumberSets",
                table: "NumberSets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NumberSets_Players_PlayerId",
                table: "NumberSets",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NumberSets_Players_PlayerId",
                table: "NumberSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NumberSets",
                table: "NumberSets");

            migrationBuilder.RenameTable(
                name: "NumberSets",
                newName: "NumberSet");

            migrationBuilder.RenameIndex(
                name: "IX_NumberSets_PlayerId",
                table: "NumberSet",
                newName: "IX_NumberSet_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NumberSet",
                table: "NumberSet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NumberSet_Players_PlayerId",
                table: "NumberSet",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

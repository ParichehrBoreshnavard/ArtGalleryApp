using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGalleryApp.Migrations
{
    public partial class update11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtworkFields",
                table: "ArtworkFields");

            migrationBuilder.DropColumn(
                name: "ArtworkField",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "Medium",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "Style",
                table: "Gallery");

            migrationBuilder.RenameTable(
                name: "ArtworkFields",
                newName: "ArtworkField_");

            migrationBuilder.AddColumn<int>(
                name: "artworkFieldId",
                table: "Gallery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "mediumId",
                table: "Gallery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "styleId",
                table: "Gallery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtworkField_",
                table: "ArtworkField_",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_artworkFieldId",
                table: "Gallery",
                column: "artworkFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_mediumId",
                table: "Gallery",
                column: "mediumId");

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_styleId",
                table: "Gallery",
                column: "styleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_ArtworkField__artworkFieldId",
                table: "Gallery",
                column: "artworkFieldId",
                principalTable: "ArtworkField_",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Mediums_mediumId",
                table: "Gallery",
                column: "mediumId",
                principalTable: "Mediums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Styles_styleId",
                table: "Gallery",
                column: "styleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_ArtworkField__artworkFieldId",
                table: "Gallery");

            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Mediums_mediumId",
                table: "Gallery");

            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Styles_styleId",
                table: "Gallery");

            migrationBuilder.DropIndex(
                name: "IX_Gallery_artworkFieldId",
                table: "Gallery");

            migrationBuilder.DropIndex(
                name: "IX_Gallery_mediumId",
                table: "Gallery");

            migrationBuilder.DropIndex(
                name: "IX_Gallery_styleId",
                table: "Gallery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtworkField_",
                table: "ArtworkField_");

            migrationBuilder.DropColumn(
                name: "artworkFieldId",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "mediumId",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "styleId",
                table: "Gallery");

            migrationBuilder.RenameTable(
                name: "ArtworkField_",
                newName: "ArtworkFields");

            migrationBuilder.AddColumn<string>(
                name: "ArtworkField",
                table: "Gallery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Medium",
                table: "Gallery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Style",
                table: "Gallery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtworkFields",
                table: "ArtworkFields",
                column: "Id");
        }
    }
}

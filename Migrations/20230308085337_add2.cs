using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGalleryApp.Migrations
{
    public partial class add2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikeGallery_Gallery_galleryId",
                table: "LikeGallery");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeGallery_Users_userId",
                table: "LikeGallery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeGallery",
                table: "LikeGallery");

            migrationBuilder.RenameTable(
                name: "LikeGallery",
                newName: "LikeGalleries");

            migrationBuilder.RenameIndex(
                name: "IX_LikeGallery_userId",
                table: "LikeGalleries",
                newName: "IX_LikeGalleries_userId");

            migrationBuilder.RenameIndex(
                name: "IX_LikeGallery_galleryId",
                table: "LikeGalleries",
                newName: "IX_LikeGalleries_galleryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeGalleries",
                table: "LikeGalleries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeGalleries_Gallery_galleryId",
                table: "LikeGalleries",
                column: "galleryId",
                principalTable: "Gallery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LikeGalleries_Users_userId",
                table: "LikeGalleries",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikeGalleries_Gallery_galleryId",
                table: "LikeGalleries");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeGalleries_Users_userId",
                table: "LikeGalleries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeGalleries",
                table: "LikeGalleries");

            migrationBuilder.RenameTable(
                name: "LikeGalleries",
                newName: "LikeGallery");

            migrationBuilder.RenameIndex(
                name: "IX_LikeGalleries_userId",
                table: "LikeGallery",
                newName: "IX_LikeGallery_userId");

            migrationBuilder.RenameIndex(
                name: "IX_LikeGalleries_galleryId",
                table: "LikeGallery",
                newName: "IX_LikeGallery_galleryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeGallery",
                table: "LikeGallery",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeGallery_Gallery_galleryId",
                table: "LikeGallery",
                column: "galleryId",
                principalTable: "Gallery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LikeGallery_Users_userId",
                table: "LikeGallery",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

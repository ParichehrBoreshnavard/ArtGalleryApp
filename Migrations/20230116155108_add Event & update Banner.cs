using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGalleryApp.Migrations
{
    public partial class addEventupdateBanner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Banners");

            migrationBuilder.RenameColumn(
                name: "imageUrl",
                table: "Banners",
                newName: "ImgUrl");

            migrationBuilder.AddColumn<int>(
                name: "Event_Id",
                table: "Banners",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrlPoster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrlAbout = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Banners_Event_Id",
                table: "Banners",
                column: "Event_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_Event_Event_Id",
                table: "Banners",
                column: "Event_Id",
                principalTable: "Event",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_Event_Event_Id",
                table: "Banners");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Banners_Event_Id",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "Event_Id",
                table: "Banners");

            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "Banners",
                newName: "imageUrl");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Banners",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Banners",
                type: "datetime2",
                nullable: true);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGalleryApp.Migrations
{
    public partial class update8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ArtistFields_ArtistField_Id",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistFields",
                table: "ArtistFields");

            migrationBuilder.RenameTable(
                name: "ArtistFields",
                newName: "ArtistField_");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistField_",
                table: "ArtistField_",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArtistField_Id = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artists_ArtistField__ArtistField_Id",
                        column: x => x.ArtistField_Id,
                        principalTable: "ArtistField_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_ArtistField_Id",
                table: "Artists",
                column: "ArtistField_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ArtistField__ArtistField_Id",
                table: "Users",
                column: "ArtistField_Id",
                principalTable: "ArtistField_",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ArtistField__ArtistField_Id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistField_",
                table: "ArtistField_");

            migrationBuilder.RenameTable(
                name: "ArtistField_",
                newName: "ArtistFields");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistFields",
                table: "ArtistFields",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ArtistFields_ArtistField_Id",
                table: "Users",
                column: "ArtistField_Id",
                principalTable: "ArtistFields",
                principalColumn: "Id");
        }
    }
}

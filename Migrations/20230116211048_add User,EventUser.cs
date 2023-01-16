using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGalleryApp.Migrations
{
    public partial class addUserEventUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_Artists_Artist_Id",
                table: "Artworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Artworks_Artwork_Id",
                table: "Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_Mediums_Artworks_Artwork_Id",
                table: "Mediums");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Artworks_Artwork_Id",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Styles_Artworks_Artwork_Id",
                table: "Styles");

            migrationBuilder.DropTable(
                name: "ArtistRegistrations");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "SignUp");

            migrationBuilder.DropIndex(
                name: "IX_Styles_Artwork_Id",
                table: "Styles");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_Artwork_Id",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Mediums_Artwork_Id",
                table: "Mediums");

            migrationBuilder.DropIndex(
                name: "IX_Fields_Artwork_Id",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "Artwork_Id",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "Artwork_Id",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "Artwork_Id",
                table: "Mediums");

            migrationBuilder.DropColumn(
                name: "Artwork_Id",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "ArtistName",
                table: "Artworks");

            migrationBuilder.AddColumn<int>(
                name: "ArtworkId",
                table: "Styles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArtworkId",
                table: "Sizes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArtworkId",
                table: "Mediums",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArtworkId",
                table: "Fields",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Artworks",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishDate",
                table: "Artworks",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Rols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Field_Id = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Fields_Field_Id",
                        column: x => x.Field_Id,
                        principalTable: "Fields",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Rols_roleId",
                        column: x => x.roleId,
                        principalTable: "Rols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Event_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventUser_Events_Event_Id",
                        column: x => x.Event_Id,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUser_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Styles_ArtworkId",
                table: "Styles",
                column: "ArtworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_ArtworkId",
                table: "Sizes",
                column: "ArtworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Mediums_ArtworkId",
                table: "Mediums",
                column: "ArtworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_ArtworkId",
                table: "Fields",
                column: "ArtworkId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_Event_Id",
                table: "EventUser",
                column: "Event_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_User_Id",
                table: "EventUser",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Field_Id",
                table: "Users",
                column: "Field_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_roleId",
                table: "Users",
                column: "roleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_Users_Artist_Id",
                table: "Artworks",
                column: "Artist_Id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Artworks_ArtworkId",
                table: "Fields",
                column: "ArtworkId",
                principalTable: "Artworks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mediums_Artworks_ArtworkId",
                table: "Mediums",
                column: "ArtworkId",
                principalTable: "Artworks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Artworks_ArtworkId",
                table: "Sizes",
                column: "ArtworkId",
                principalTable: "Artworks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Styles_Artworks_ArtworkId",
                table: "Styles",
                column: "ArtworkId",
                principalTable: "Artworks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_Users_Artist_Id",
                table: "Artworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Artworks_ArtworkId",
                table: "Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_Mediums_Artworks_ArtworkId",
                table: "Mediums");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Artworks_ArtworkId",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Styles_Artworks_ArtworkId",
                table: "Styles");

            migrationBuilder.DropTable(
                name: "EventUser");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rols");

            migrationBuilder.DropIndex(
                name: "IX_Styles_ArtworkId",
                table: "Styles");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_ArtworkId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Mediums_ArtworkId",
                table: "Mediums");

            migrationBuilder.DropIndex(
                name: "IX_Fields_ArtworkId",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "ArtworkId",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "ArtworkId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "ArtworkId",
                table: "Mediums");

            migrationBuilder.DropColumn(
                name: "ArtworkId",
                table: "Fields");

            migrationBuilder.AddColumn<int>(
                name: "Artwork_Id",
                table: "Styles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Artwork_Id",
                table: "Sizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Artwork_Id",
                table: "Mediums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Artwork_Id",
                table: "Fields",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "price",
                table: "Artworks",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishDate",
                table: "Artworks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArtistName",
                table: "Artworks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    YearOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SignUp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtistRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SignUps_Id = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    YearOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistRegistrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistRegistrations_SignUp_SignUps_Id",
                        column: x => x.SignUps_Id,
                        principalTable: "SignUp",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Styles_Artwork_Id",
                table: "Styles",
                column: "Artwork_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_Artwork_Id",
                table: "Sizes",
                column: "Artwork_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mediums_Artwork_Id",
                table: "Mediums",
                column: "Artwork_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_Artwork_Id",
                table: "Fields",
                column: "Artwork_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistRegistrations_SignUps_Id",
                table: "ArtistRegistrations",
                column: "SignUps_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_Artists_Artist_Id",
                table: "Artworks",
                column: "Artist_Id",
                principalTable: "Artists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Artworks_Artwork_Id",
                table: "Fields",
                column: "Artwork_Id",
                principalTable: "Artworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mediums_Artworks_Artwork_Id",
                table: "Mediums",
                column: "Artwork_Id",
                principalTable: "Artworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Artworks_Artwork_Id",
                table: "Sizes",
                column: "Artwork_Id",
                principalTable: "Artworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Styles_Artworks_Artwork_Id",
                table: "Styles",
                column: "Artwork_Id",
                principalTable: "Artworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

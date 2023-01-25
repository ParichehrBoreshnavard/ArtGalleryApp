﻿// <auto-generated />
using System;
using ArtGalleryApp.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArtGalleryApp.Migrations
{
    [DbContext(typeof(dbSarvContext))]
    partial class dbSarvContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Artwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Artist_Id")
                        .HasColumnType("int");

                    b.Property<bool>("Availability")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProduceDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SoldDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Artist_Id");

                    b.ToTable("Artworks");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Event_Id")
                        .HasColumnType("int");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PublishEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PublishStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Event_Id");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Article")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("WrittenDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Contact", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Event_", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AboutDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImgUrlAbout")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrlPoster")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlTicketStore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events_");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.EventUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Event_Id")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Event_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("EventUser");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ArtworkId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtworkId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.General", b =>
                {
                    b.Property<int>("AboutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AboutId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AboutId");

                    b.ToTable("Generals");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Medium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ArtworkId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtworkId");

                    b.ToTable("Mediums");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rols");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.RoleUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Role_Id")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Role_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ArtworkId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtworkId");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ArtworkId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtworkId");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.SubEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("Events_Id")
                        .HasColumnType("int");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsTicket")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("StartDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlTicketStore")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Events_Id");

                    b.ToTable("SubEvents");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.TagBlog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Blog_Id")
                        .HasColumnType("int");

                    b.Property<int>("Tag_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Blog_Id");

                    b.HasIndex("Tag_Id");

                    b.ToTable("TagBlog");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.TeamMember", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Field_Id")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PortfolioUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("YearOfBirth")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Field_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Artwork", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.User", "Artist_")
                        .WithMany("Artworks")
                        .HasForeignKey("Artist_Id");

                    b.Navigation("Artist_");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Banner", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.Event_", "Event_")
                        .WithMany()
                        .HasForeignKey("Event_Id");

                    b.Navigation("Event_");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.EventUser", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.Event_", "Event_")
                        .WithMany("EventUsers")
                        .HasForeignKey("Event_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArtGalleryApp.Models.Data.User", "User_")
                        .WithMany("EventUsers")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event_");

                    b.Navigation("User_");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Field", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.Artwork", null)
                        .WithMany("Fields")
                        .HasForeignKey("ArtworkId");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Medium", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.Artwork", null)
                        .WithMany("Mediums")
                        .HasForeignKey("ArtworkId");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.RoleUser", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.Role", "Role_")
                        .WithMany("RoleUsers")
                        .HasForeignKey("Role_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArtGalleryApp.Models.Data.User", "User_")
                        .WithMany("RoleUsers")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role_");

                    b.Navigation("User_");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Size", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.Artwork", null)
                        .WithMany("Sizes")
                        .HasForeignKey("ArtworkId");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Style", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.Artwork", null)
                        .WithMany("Styles")
                        .HasForeignKey("ArtworkId");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.SubEvent", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.Event_", "Events_")
                        .WithMany("SubEvents")
                        .HasForeignKey("Events_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Events_");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.TagBlog", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.Blog", "Blog_")
                        .WithMany("TagBlogs")
                        .HasForeignKey("Blog_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArtGalleryApp.Models.Data.Tag", "Tag_")
                        .WithMany("TagBlogs")
                        .HasForeignKey("Tag_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog_");

                    b.Navigation("Tag_");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.TeamMember", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.User", "User_")
                        .WithMany("TeamMembers")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User_");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.User", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.Field", "Field_")
                        .WithMany()
                        .HasForeignKey("Field_Id");

                    b.Navigation("Field_");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Artwork", b =>
                {
                    b.Navigation("Fields");

                    b.Navigation("Mediums");

                    b.Navigation("Sizes");

                    b.Navigation("Styles");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Blog", b =>
                {
                    b.Navigation("TagBlogs");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Event_", b =>
                {
                    b.Navigation("EventUsers");

                    b.Navigation("SubEvents");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Role", b =>
                {
                    b.Navigation("RoleUsers");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Tag", b =>
                {
                    b.Navigation("TagBlogs");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.User", b =>
                {
                    b.Navigation("Artworks");

                    b.Navigation("EventUsers");

                    b.Navigation("RoleUsers");

                    b.Navigation("TeamMembers");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using ArtGalleryApp.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArtGalleryApp.Migrations
{
    [DbContext(typeof(dbSarvContext))]
    [Migration("20230116183443_add ArtistRegistration, SignUp")]
    partial class addArtistRegistrationSignUp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<DateTime>("YearOfBirth")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.ArtistRegistration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int?>("SignUps_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("YearOfBirth")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SignUps_Id");

                    b.ToTable("ArtistRegistrations");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Artwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ArtistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<DateTime>("ProduceDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("price")
                        .HasColumnType("int");

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

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Event", b =>
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

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Artwork_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Artwork_Id");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Medium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Artwork_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Artwork_Id");

                    b.ToTable("Mediums");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.SignUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SignUp");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Artwork_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Artwork_Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Artwork_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Artwork_Id");

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

                    b.Property<int?>("EventId")
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

                    b.HasIndex("EventId");

                    b.ToTable("SubEvents");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.ArtistRegistration", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.SignUp", "SignUps_")
                        .WithMany("ArtistRegistrations")
                        .HasForeignKey("SignUps_Id");

                    b.Navigation("SignUps_");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Artwork", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.Artist", "Artist_")
                        .WithMany("Artworks")
                        .HasForeignKey("Artist_Id");

                    b.Navigation("Artist_");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Banner", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.Event", "Event_")
                        .WithMany()
                        .HasForeignKey("Event_Id");

                    b.Navigation("Event_");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Field", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.Artwork", "Artwork_")
                        .WithMany("Fields")
                        .HasForeignKey("Artwork_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artwork_");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Medium", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.Artwork", "Artwork_")
                        .WithMany("Mediums")
                        .HasForeignKey("Artwork_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artwork_");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Size", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.Artwork", "Artwork_")
                        .WithMany("Sizes")
                        .HasForeignKey("Artwork_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artwork_");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Style", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.Artwork", "Artwork_")
                        .WithMany("Styles")
                        .HasForeignKey("Artwork_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artwork_");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.SubEvent", b =>
                {
                    b.HasOne("ArtGalleryApp.Models.Data.Event", null)
                        .WithMany("SubEvents")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Artist", b =>
                {
                    b.Navigation("Artworks");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Artwork", b =>
                {
                    b.Navigation("Fields");

                    b.Navigation("Mediums");

                    b.Navigation("Sizes");

                    b.Navigation("Styles");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.Event", b =>
                {
                    b.Navigation("SubEvents");
                });

            modelBuilder.Entity("ArtGalleryApp.Models.Data.SignUp", b =>
                {
                    b.Navigation("ArtistRegistrations");
                });
#pragma warning restore 612, 618
        }
    }
}

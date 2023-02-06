﻿using ArtGalleryApp.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace ArtGalleryApp.Context
{
    public class dbSarvContext : DbContext
    {
        public dbSarvContext(DbContextOptions<dbSarvContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Banner> Banners { get; set; }
        public DbSet<Event_> Events_ { get; set; }
        public DbSet<SubEvent> SubEvents { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Medium> Mediums { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Role> Rols { get; set; }
        public DbSet<EventUser> EventUsers { get; set; }
        public DbSet<RoleUser> RoleUser { get; set; }
        public DbSet<TagGallery> TagGallery { get; set; }
        public DbSet<TagBlog> TagBlog { get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<TeamMember> Teams { get; set; }
        public DbSet<General> Generals { get; set; }
        public DbSet<Tag> Tags { get; set; }
 

    }
}

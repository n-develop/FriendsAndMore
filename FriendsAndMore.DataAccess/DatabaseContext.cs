﻿using Microsoft.EntityFrameworkCore;
using FriendsAndMore.DataAccess.Entities;

namespace FriendsAndMore.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().HasData(new Contact {ContactId = 1, FirstName = "Max", LastName = "Mustermann"});
            modelBuilder.Entity<Contact>().HasData(new Contact {ContactId = 2, FirstName = "Manuela", LastName = "Mustermann"});
            modelBuilder.Entity<Contact>().HasData(new Contact {ContactId = 3, FirstName = "John", LastName = "Smith"});
        }
    }
}
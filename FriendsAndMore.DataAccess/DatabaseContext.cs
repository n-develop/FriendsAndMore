using System;
using Microsoft.EntityFrameworkCore;
using FriendsAndMore.DataAccess.Entities;

namespace FriendsAndMore.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<StatusUpdate> StatusUpdates { get; set; }
        public DbSet<TelephoneNumber> TelephoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Contact>().HasData(new Contact {Id = 1, FirstName = "Max", LastName = "Mustermann"});
            modelBuilder.Entity<Contact>().HasData(new Contact {Id = 2, FirstName = "Manuela", LastName = "Mustermann"});
            modelBuilder.Entity<Contact>().HasData(new Contact {Id = 3, FirstName = "John", LastName = "Smith"});

            modelBuilder.Entity<TelephoneNumber>().HasData(new TelephoneNumber
            {
                Id = 1,
                ContactId = 1,
                Telephone = "555 - 2019383",
                Type = "Private"
            });
            modelBuilder.Entity<TelephoneNumber>().HasData(new TelephoneNumber
            {
                Id = 2,
                ContactId = 1,
                Telephone = "555 - 77352",
                Type = "Work"
            });
            modelBuilder.Entity<TelephoneNumber>().HasData(new TelephoneNumber
            {
                Id = 3,
                ContactId = 2,
                Telephone = "555 - 104834",
                Type = "Private"
            });
            modelBuilder.Entity<TelephoneNumber>().HasData(new TelephoneNumber
            {
                Id = 4,
                ContactId = 3,
                Telephone = "555 - 095237",
                Type = "Mobile"
            });
            
            modelBuilder.Entity<StatusUpdate>().HasData(new StatusUpdate
            {
                Id = 1,
                ContactId = 3,
                StatusText = "He quit his job.",
                Created = new DateTime(2020, 3, 4)
            });
            
            modelBuilder.Entity<Relationship>().HasData(new Relationship
            {
                Id = 1,
                ContactId = 1,
                Person = "Manuela Mustermann",
                Type = "Wife"
            });
            modelBuilder.Entity<Relationship>().HasData(new Relationship
            {
                Id = 2,
                ContactId = 2,
                Person = "Max Mustermann",
                Type = "Husband"
            });
            
            modelBuilder.Entity<EmailAddress>().HasData(new EmailAddress
            {
                Id = 1, 
                Email = "max@mustermann.de", 
                Type = "private", 
                ContactId = 1
            });
            modelBuilder.Entity<EmailAddress>().HasData(new EmailAddress
            {
                Id = 2, 
                Email = "manuela@mustermann.de", 
                Type = "private", 
                ContactId = 2
            });
            modelBuilder.Entity<EmailAddress>().HasData(new EmailAddress
            {
                Id = 3, 
                Email = "john.smith@ee-mail.de", 
                Type = "private", 
                ContactId = 3
            });
            modelBuilder.Entity<EmailAddress>().HasData(new EmailAddress
            {
                Id = 4, 
                Email = "max@enterprise-stuff.de", 
                Type = "work", 
                ContactId = 1
            });
        }
    }
}
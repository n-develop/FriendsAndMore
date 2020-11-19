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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Contact>().HasData(new Contact {ContactId = 1, FirstName = "Max", LastName = "Mustermann"});
            modelBuilder.Entity<Contact>().HasData(new Contact {ContactId = 2, FirstName = "Manuela", LastName = "Mustermann"});
            modelBuilder.Entity<Contact>().HasData(new Contact {ContactId = 3, FirstName = "John", LastName = "Smith"});
            
            modelBuilder.Entity<EmailAddress>().HasData(new EmailAddress
            {
                EmailAddressId = 1, 
                Email = "max@mustermann.de", 
                Type = "private", 
                ContactId = 1
            });
            modelBuilder.Entity<EmailAddress>().HasData(new EmailAddress
            {
                EmailAddressId = 2, 
                Email = "manuela@mustermann.de", 
                Type = "private", 
                ContactId = 2
            });
            modelBuilder.Entity<EmailAddress>().HasData(new EmailAddress
            {
                EmailAddressId = 3, 
                Email = "john.smith@ee-mail.de", 
                Type = "private", 
                ContactId = 3
            });
            modelBuilder.Entity<EmailAddress>().HasData(new EmailAddress
            {
                EmailAddressId = 4, 
                Email = "max@enterprise-stuff.de", 
                Type = "work", 
                ContactId = 1
            });
        }
    }
}